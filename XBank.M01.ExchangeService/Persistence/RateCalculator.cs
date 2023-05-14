using XBank.ExchangeService.Entities;
using XBank.M01.ExchangeService.Entities;

namespace XBank.M01.ExchangeService.Persistence
{
    public class RateCalculator
    {
        public static ExchangeItem CalculateRate(ExchangeRequestItem requestItem, ExchangeItem rateResult)
        {
            try
            {
                var exchangeItem = new ExchangeItem { FromCurrency = requestItem.FromCurrency, ToCurrency = requestItem.ToCurrency, FromAmount = requestItem.FromAmount };

                if (requestItem.FromCurrency == requestItem.ToCurrency) { return default!; }

                if (!string.IsNullOrEmpty(requestItem.FromAmount))
                {
                    var amount = float.Parse(requestItem.FromAmount);
                    var rate = float.Parse(rateResult.Rate);

                    if (rate == 0) return default!;

                    var calculatedAmount = amount * rate;

                    exchangeItem.Rate = rateResult.Rate;
                    exchangeItem.ToAmount = calculatedAmount.ToString();
                    exchangeItem.RateTime = rateResult.RateTime;
                }

                return exchangeItem;
            }
            catch (Exception ex)
            {
                throw;
            }
          
        }
    }
}
