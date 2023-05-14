using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;
using XBank.M03.TransactionService.Entities;

namespace XBank.M03.TransactionService.Repository
{
    public class ExchangeTransactionRepository
    {
        private readonly IDistributedCache _distributedCache;

        public ExchangeTransactionRepository(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<bool> AddExchangeTransaction(ClientExchangeTransaction clientExchangeTransaction)
        {
            // Get Cached
            var byteResponse = await _distributedCache.GetAsync("XBank", CancellationToken.None);
            if (byteResponse != null)
            {
                var stringResponse = Encoding.UTF8.GetString(byteResponse!);
                var objectResponse = JsonSerializer.Deserialize<ExchangeTransactionCache>(stringResponse);

                // Validate Transaction
                var firstAddedTime = objectResponse!.TransactionTimes.First();
                TimeSpan ts = DateTime.UtcNow - firstAddedTime;
                if (objectResponse.TransactionTimes.Count == 10 && ts.Minutes < 60)
                {
                    objectResponse.TransactionTimes.Add(DateTime.UtcNow);
                    return true;
                }


                if (objectResponse!.TransactionTimes.Count == 10)
                {
                    objectResponse.TransactionTimes.RemoveAt(0);
                    objectResponse!.TransactionTimes.Add(DateTime.UtcNow);
                }
            }
            else 
            {
                var cacheObjt = new ExchangeTransactionCache { ClientId = clientExchangeTransaction.ClientId, TransactionTimes = new List<DateTime>() { DateTime.UtcNow } };
                var serializedData = JsonSerializer.Serialize(cacheObjt);
                var dataAsByteArray = Encoding.UTF8.GetBytes(serializedData);
                await _distributedCache.SetAsync("XBank", dataAsByteArray);
            }


            // Transaction Operations Executed

            return true;
        }
    }
}
