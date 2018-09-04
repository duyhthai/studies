using System;
using CurrencyExchange.Predictor;
using Xunit;

namespace CurrencyExchange.IntegrationTest
{
    public class PredictorProgramTest
    {
        [Theory]
        [InlineData("2017/1/15")]
        [InlineData("2018/6/30")]
        public void ExecuteProgram_ValidData_ShouldSucceed(string dateToPredict)
        {
            // Act
            string openExchangeAppID = Program.Configuration["OpenExchange:AppID"];
            bool result = Program.ExecuteCurrencyExchangePredictor(
                openExchangeAppID, DateTime.Parse(dateToPredict), new MockLineReader());

            // Assert
            Assert.True(result);
        }
    }
}
