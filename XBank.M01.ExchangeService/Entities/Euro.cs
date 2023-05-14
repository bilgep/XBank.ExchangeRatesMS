namespace XBank.ExchangeService.Entities
{
    public class Euro : ICurrency
    {
        public int CurrencyId { get; } = default!;
        public string CurrencyName { get => CurrenyNames.Euro; }

    }
}
