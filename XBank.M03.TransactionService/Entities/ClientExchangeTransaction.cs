namespace XBank.M03.TransactionService.Entities
{
    public class ClientExchangeTransaction
    {
        public long Id { get; set; }
        public long ClientId { get; set; }
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public DateTime TransactionRequestTime { get; set; }
        public string TransactionAmount { get; set; }
    }
}
