using Microsoft.EntityFrameworkCore;
using XBank.M02.ClientService.Data;
using XBank.M02.ClientService.Entities;

namespace XBank.M02.ClientService.Repository
{
    public class ClientRepository
    {
        private readonly ClientDbContext _dbContext;
        private readonly ILogger<ClientRepository> _logger;

        public ClientRepository(ClientDbContext dbContext, ILogger<ClientRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<string> GetClientBalance(string clientId, string accountType)
        {
            try
            {
                var status = long.TryParse(clientId, out var parsedId);
                if (status)
                {
                    var result = await _dbContext.ClientAccounts.FirstOrDefaultAsync(x => x.ClientId == parsedId && x.AccountType == accountType);
                    if (result != null)
                    {
                        var account = await _dbContext.Accounts.FirstOrDefaultAsync(x => x.AccountId == result.AccountId);
                        return account != null ? account.Balance : default!;
                    }

                    return default!;

                }
                else
                {
                    _logger.LogError("Invalid client Id");
                    throw new Exception();
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                throw;
            }
        }
    }
}
