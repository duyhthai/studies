using System;
using System.Collections.Generic;
using System.Text;
using CurrencyExchange.Core.Math;
using Xunit;

namespace CurrencyExchange.UnitTest
{
    public class LinearRegressionTest
    {
        [Theory]
        [InlineData(new int[] { 1, 2 }, new double[] { 23000 }, 1)]
        public void PredictCurrencyExchangeRate_DifferentArrayLengths_ShouldFail(int[] xVals, double[] yVals, int monthToPredict)
        {
            // Act
            Action act = () => LinearRegression.PredictCurrencyExchangeRate(xVals, yVals, monthToPredict);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Theory]
        [InlineData(
            new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 },
            new double[] { 22403.166667, 22337.666667, 22291.333333, 22335.5, 22345, 22331.833333, 22311.65, 22293.833333, 22338.4, 22296.033333, 22367.816667, 22697.5 },
            1,
            22297.425213730767)]
        public void PredictCurrencyExchangeRate_ValidData_ShouldSucceed(int[] xVals, double[] yVals, int monthToPredict, double expectedValue)
        {
            // Act
            double actualValue = LinearRegression.PredictCurrencyExchangeRate(xVals, yVals, monthToPredict);

            // Assert
            Assert.Equal(expectedValue, actualValue);
        }
    }
}
