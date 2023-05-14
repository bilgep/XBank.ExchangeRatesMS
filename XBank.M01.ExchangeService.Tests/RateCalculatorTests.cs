using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBank.ExchangeService.Entities;
using XBank.M01.ExchangeService.Entities;
using XBank.M01.ExchangeService.Persistence;

namespace XBank.M01.ExchangeService.Tests
{
    public class RateCalculatorTests
    {
        [Fact]
        public void WhenFromUsdToUsd_RateIsFromUsdToEuro_ReturnDefault()
        {
            // Arrange
            var exchangeRequestItem = new ExchangeRequestItem { FromAmount = "10", FromCurrency = CurrenyNames.Usd, ToCurrency = CurrenyNames.Usd };
            var exchangeItem = new ExchangeItem { Rate = "1.5" };
            
            // Act
            var response = RateCalculator.CalculateRate(exchangeRequestItem, exchangeItem);

            // Assert
            Assert.Equal(default!, response);
        }


        [Fact]
        public void WhenFromUsdToEuro_RateIsZero_ReturnDefault()
        {
            // Arrange
            var exchangeRequestItem = new ExchangeRequestItem { FromAmount = "10", FromCurrency = CurrenyNames.Usd, ToCurrency = CurrenyNames.Euro };
            var exchangeItem = new ExchangeItem { Rate = "0" };

            // Act
            var response = RateCalculator.CalculateRate(exchangeRequestItem, exchangeItem);

            // Assert
            Assert.Equal(default!, response);
        }
    }
}
