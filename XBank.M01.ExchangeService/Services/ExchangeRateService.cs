using XBank.ExchangeService.Entities;
using XBank.M01.ExchangeService.Entities;

namespace XBank.ExchangeService.Services
{
    public class ExchangeRateService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ExchangeRateService> _logger;

        public ExchangeRateService(IHttpClientFactory httpClientFactory, IConfiguration configuration, ILogger<ExchangeRateService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<ExchangeItem> GetExchangeRate(ExchangeRequestItem exchangeRequest)
        {
            try
            {
                var requestUrl = new Uri($"https://api.collectapi.com/economy/exchange?int=10&to={exchangeRequest.ToCurrency}&base={exchangeRequest.FromCurrency}");
                var client = _httpClientFactory.CreateClient();
                client.DefaultRequestHeaders.Add("authorization", _configuration["ApiKey"]);
                var httpResponse = await client.GetFromJsonAsync<ExchangeResponseItem>(requestUrl);
                var responseItem = new ExchangeItem();
                // implement automapper
                // null check
                if (httpResponse != null && httpResponse.Result.Data.Count > 0)
                {

                    responseItem.FromCurrency = exchangeRequest.FromCurrency;
                    responseItem.ToCurrency = exchangeRequest.ToCurrency;
                    responseItem.Rate = httpResponse!.Result.Data[0].Rate;
                    responseItem.RateTime = httpResponse!.Result.LastUpdate;

                }


                return responseItem;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                return null;
            }
           

        }
    }
}
