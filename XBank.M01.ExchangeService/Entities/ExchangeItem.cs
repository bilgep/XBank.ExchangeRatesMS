namespace XBank.M01.ExchangeService.Entities
{
    public class ExchangeItem
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public string RateTime { get; set; }
        public string Rate { get; set; }
        public string? FromAmount { get; set; } = default!;
        public string? ToAmount { get; set; } = default!;
    }
}
