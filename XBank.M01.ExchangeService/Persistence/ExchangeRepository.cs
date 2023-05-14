using Microsoft.Extensions.Caching.Memory;
using XBank.ExchangeService.Entities;
using XBank.ExchangeService.Services;
using XBank.M01.ExchangeService.CacheItems;
using XBank.M01.ExchangeService.Entities;

namespace XBank.M01.ExchangeService.Persistence
{
    public class ExchangeRepository : IExchangeRepositorty
    {
        private readonly ExchangeRateService _exchangeRateService;
        private readonly IMemoryCache _inMemoryCache;

        public ExchangeRepository(ExchangeRateService exchangeRateService, IMemoryCache inMemoryCache)
        {
            _exchangeRateService = exchangeRateService ?? throw new ArgumentNullException(nameof(exchangeRateService));
            _inMemoryCache = inMemoryCache ?? throw new ArgumentNullException(nameof(inMemoryCache));
        }

        private async Task<ExchangeItem> GetRate(ExchangeRequestItem exchangeRequestItem)
        {
            var response = await _exchangeRateService.GetExchangeRate(exchangeRequestItem);

            return response;
        }

        public async Task<ExchangeItem> GetCalculatedAmount(ExchangeRequestItem exchangeRequestItem)
        {
            // if it's not in in-memory cache or it's not up tpo date, get latest rates from API
            var cacheKey = exchangeRequestItem.FromCurrency + "To" + exchangeRequestItem.ToCurrency;
            var cachedRate = _inMemoryCache.TryGetValue(cacheKey, out ExchangeRateCache exchangeCache);

            var rateResult = new ExchangeItem();

            if (cachedRate)
            {
                rateResult.Rate = exchangeCache.CachedRate;
                rateResult.FromCurrency = exchangeRequestItem.FromCurrency;
                rateResult.ToCurrency = exchangeRequestItem.ToCurrency;
                rateResult.RateTime = exchangeCache.CachedTime;
                rateResult.FromAmount = exchangeRequestItem.FromAmount;
            }
            else
            {
                rateResult = await GetRate(exchangeRequestItem);

                // cached value expires after 30 minutes
                var newExchangeRateForCache = new ExchangeRateCache() { CachedTime = rateResult.RateTime, CachedRate = rateResult.Rate, FromCurrency = exchangeRequestItem.FromCurrency, ToCurrency = exchangeRequestItem.ToCurrency };
                _inMemoryCache.Set(cacheKey, newExchangeRateForCache, TimeSpan.FromMinutes(30));
            }

            var response = RateCalculator.CalculateRate(exchangeRequestItem, rateResult);

            return response;
        }
    }
}
