namespace XBank.ExchangeService.Entities
{
    public class ExchangeRequestItem
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public DateTime RequestTime { get; set; }
    }
}
