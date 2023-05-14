using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBank.ExchangeService.Entities;
using XBank.ExchangeService.Services;

namespace XBank.M01.ExchangeService.Tests
{
    public class ExchangeServiceTests
    {
        private readonly Mock<IHttpClientFactory> mockIHttpClient;
        private readonly Mock<IConfiguration> mockConfiguration;
        private readonly Mock<ILogger<ExchangeRateService>> mockLogger;
        private readonly ExchangeRateService exchangeRateService;

        public ExchangeServiceTests()
        {
            mockIHttpClient = new Mock<IHttpClientFactory>();
            var client = new HttpClient();

            mockIHttpClient.Setup(x => x.CreateClient(It.IsAny<string>())).Returns(client);
            mockLogger = new Mock<ILogger<ExchangeRateService>>();

            mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.Setup(x => x["ApiKey"]).Returns("put_your_apikey");

            exchangeRateService = new ExchangeRateService(mockIHttpClient.Object, mockConfiguration.Object, mockLogger.Object);
        }


        [Fact]
        public async Task GetExchangeRate_ValidRequest_ResponseNotNull()
        {
            // Arrange
            var exchangeRequestItem = new ExchangeRequestItem 
            { 
                FromCurrency = CurrenyNames.Usd,
                ToCurrency = CurrenyNames.Euro,
                FromAmount = "10",
                RequestTime = DateTime.UtcNow.ToString()
            };

            // Act
            var response = await exchangeRateService.GetExchangeRate(exchangeRequestItem);

            // Assert
            Assert.NotNull(response);
        }

        // Test Cases
        // Valid exchangeRequest => ExchangeResponseItem not null, other property comparisons
        // Invalid exchange requestv => ExchangeResponseItem is null
    }
}
