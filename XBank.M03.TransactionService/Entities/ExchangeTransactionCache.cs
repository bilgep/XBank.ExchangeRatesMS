namespace XBank.M03.TransactionService.Entities
{
    public class ExchangeTransactionCache
    {
        public int Id { get; set; }
        public long ClientId { get; set; }
        public List<DateTime> TransactionTimes { get; set; }
    }
}
