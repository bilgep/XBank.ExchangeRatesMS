using XBank.ExchangeService.Entities;
using XBank.M01.ExchangeService.Entities;

namespace XBank.M01.ExchangeService.Persistence
{
    public interface IExchangeRepositorty
    {
        Task<ExchangeItem> GetCalculatedAmount(ExchangeRequestItem exchangeRequestItem);
    }
}
