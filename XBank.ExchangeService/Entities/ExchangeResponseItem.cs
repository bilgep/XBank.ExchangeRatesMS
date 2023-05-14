namespace XBank.ExchangeService.Entities
{
    public class ExchangeResponseItem
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public float Rate { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}
