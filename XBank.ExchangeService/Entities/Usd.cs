namespace XBank.ExchangeService.Entities
{
    public class Usd : ICurrency
    {
        public int CurrencyId { get; set; } = default!;
        public string CurrencyName { get => CurrenyNames.Euro; }
    }
}
