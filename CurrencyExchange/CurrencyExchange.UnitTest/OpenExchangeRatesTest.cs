using System;
using CurrencyExchange.Core.Api;
using Xunit;

namespace CurrencyExchange.UnitTest
{
    public class OpenExchangeRatesTest
    {
        private OpenExchangeRates openExchangeRate;

        public OpenExchangeRatesTest()
        {
            openExchangeRate = new OpenExchangeRates("e4280622a7e442b9959a19f7e52745c1");
        }

        [Theory]
        [InlineData("2016-01-15", "USD")]
        [InlineData("2016-12-15", "CAD")]
        public void GetHistoricalData_ValidData_ShouldSucceed(string date, string baseCurrency)
        {
            // Act
            Rates rates = openExchangeRate.GetHistoricalData(date, baseCurrency);

            // Assert
            Assert.NotNull(rates);
        }

        [Theory]
        [InlineData("2020-01-15", "USD")]
        [InlineData("2016/12/15", "CAD")]
        public void GetHistoricalData_InvalidData_ShouldFail(string date, string baseCurrency)
        {
            // Act
            Action act = () => openExchangeRate.GetHistoricalData(date, baseCurrency);

            // Assert
            Assert.Throws<Exception>(act);
        }
    }
}
