namespace XBank.M01.ExchangeService.CacheItems
{
    public class ExchangeRateCache
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public string CachedRate { get; set; }
        public string CachedTime { get; set; }
    }
}
