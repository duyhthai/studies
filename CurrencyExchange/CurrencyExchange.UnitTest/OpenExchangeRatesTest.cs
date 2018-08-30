using CurrencyExchange.Core.Api;
using Xunit;

namespace CurrencyExchange.UnitTest
{
    public class OpenExchangeRatesTest
    {
        private OpenExchangeRates openExchangeRate;

        public OpenExchangeRatesTest()
        {
            openExchangeRate = new OpenExchangeRates("20918cbea86a4c51b1d8d4886d0afb7a");
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
            Rates rates = openExchangeRate.GetHistoricalData(date, baseCurrency);

            // Assert
            Assert.Null(rates);
        }
    }
}
