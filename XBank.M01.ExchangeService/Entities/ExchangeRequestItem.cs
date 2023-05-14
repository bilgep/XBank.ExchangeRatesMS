namespace XBank.ExchangeService.Entities
{
    public class ExchangeRequestItem
    {
        public string FromCurrency { get; set; } = default!;
        public string ToCurrency { get; set; } = default!;
        public string? FromAmount { get; set; } = default!;
        public string RequestTime { get; set; } = default!;
    }
}
