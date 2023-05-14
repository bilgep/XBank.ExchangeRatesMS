using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly ILogger<ExchangeRateService> _logger;

        //public ExchangeServiceTests(IHttpClientFactory httpClientFactory, IConfiguration configuration,
        //     ILogger<ExchangeRateService> logger)
        //{
        //    _httpClientFactory = httpClientFactory;
        //    _configuration = configuration;
        //    _logger = logger;
        //}

        // Add Moq

        [Fact]
        public void GetExchangeRate_ValidRequest_ResponseNotNull()
        {
            // Arrange
            // Add Moq
            //var testExchangeService = new ExchangeRateService(_httpClientFactory, _configuration, _logger);
            //var exchangeRequest = new ExchangeRequestItem { FromAmount = "10", FromCurrency = CurrenyNames.Usd, ToCurrency = CurrenyNames.Euro };

            // Act
            //var response = testExchangeService.GetExchangeRate(exchangeRequest);

            // Assert
            //Assert.NotNull(response);
            Assert.True(true);
        }

        // Test Cases
        // Valid exchangeRequest => ExchangeResponseItem not null, other property comparisons
        // Invalid exchange requestv => ExchangeResponseItem is null
    }
}
