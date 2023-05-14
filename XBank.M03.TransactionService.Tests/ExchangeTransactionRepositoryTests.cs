using Microsoft.Extensions.Caching.Distributed;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using XBank.M03.TransactionService.Entities;
using XBank.M03.TransactionService.Repository;

namespace XBank.M03.TransactionService.Tests
{
    public class ExchangeTransactionRepositoryTests
    {
        private readonly ExchangeTransactionRepository _exchangeTransactionRepository;
        private readonly Mock<IDistributedCache> _mockIDistributedCache;
        public ExchangeTransactionRepositoryTests()
        {
            _mockIDistributedCache = new Mock<IDistributedCache>();
            _exchangeTransactionRepository = new ExchangeTransactionRepository(_mockIDistributedCache.Object);
        }

        [Fact]
        public void When_MoreThan10TransactionRequestComes_FirstTransactionCameWithinOneHour_ReturnsFalse()
        { 
            // Arrange
            var clientExchangeTransaction = new ClientExchangeTransaction() { ClientId = 1, FromCurrency = TransactionCurrencyNames.Usd, ToCurrency = TransactionCurrencyNames.Euro , TransactionRequestTime = DateTime.UtcNow};
            var now =  DateTime.UtcNow;

            var beforeCache = new ExchangeTransactionCache { ClientId = 1 , TransactionTimes = new List<DateTime> 
            { 
                now.AddMinutes(-59), now.AddMinutes(-50), now.AddMinutes(-48), now.AddMinutes(-40), now.AddMinutes(-35), now.AddMinutes(-30), now.AddMinutes(-20), now.AddMinutes(-10), now.AddMinutes(-8), now.AddMinutes(-5)
            } };

            var serializedData = JsonSerializer.Serialize(beforeCache);
            var dataAsByteArray = Encoding.UTF8.GetBytes(serializedData);
            _mockIDistributedCache.Setup(x => x.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(dataAsByteArray));

            // Act
            var response = _exchangeTransactionRepository.AddExchangeTransaction(clientExchangeTransaction);

            // Assert
            Assert.True(response.Result);
        }

        [Fact]
        public void When_10TransactionRequestComes_ReturnsTrue()
        {
        }

        [Fact]
        public void When_FirstTransactionRequestComes_ReturnsTrue()
        {
        }
    }
}
