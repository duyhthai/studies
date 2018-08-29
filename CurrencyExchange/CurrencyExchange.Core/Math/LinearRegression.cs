using System;

namespace CurrencyExchange.Core.Math
{
    public static class LinearRegression
    {
        /// <summary>
        /// Predict currency exchange rate of a month based on previous 12 months.
        /// </summary>
        /// <param name="xVals">12 previous months.</param>
        /// <param name="yVals">Exchange rate of the 12 months.</param>
        /// <param name="monthToPredict">The month that needs to be predicted.</param>
        /// <returns></returns>
        public static double PredictCurrencyExchangeRate(int[] xVals, double[] yVals, int monthToPredict)
        {
            // Get slope and intercept
            double slope, intercept;
            CalculateSlopeAndIntercept(xVals, yVals, out slope, out intercept);

            // Regression Equation(y) = a + bx 
            double predictedValue = intercept + (slope * monthToPredict);

            return predictedValue;
        }

        /// <summary>
        /// Calculate Slope and Intercept based on collection of (x,y) points.
        /// </summary>
        /// <param name="xVals">The x-axis values.</param>
        /// <param name="yVals">The y-axis values.</param>
        /// <param name="slope">The slop of the line.</param>
        /// <param name="intercept">The y-intercept value of the line.</param>
        public static void CalculateSlopeAndIntercept(int[] xVals, double[] yVals, out double slope, out double intercept)
        {
            if (xVals.Length != yVals.Length)
            {
                throw new ArgumentException("Values' lengths not match.");
            }

            // Declare variables
            int length = xVals.Length;
            double sumOfX = 0;
            double sumOfY = 0;
            double sumOfXY = 0;
            double sumOfSquareX = 0;

            // Find ΣX, ΣY, ΣXY, ΣX2
            for (var i = 0; i < xVals.Length; i++)
            {
                var x = xVals[i];
                var y = yVals[i];
                sumOfX += x;
                sumOfY += y;
                sumOfXY += x * y;
                sumOfSquareX += x * x;
            }

            // Slope(b) = (NΣXY - (ΣX)(ΣY)) / (NΣX2 - (ΣX)2)
            slope = ((length * sumOfXY) - (sumOfX * sumOfY)) / ((length * sumOfSquareX) - (sumOfX * sumOfX));

            // Intercept(a) = (ΣY - b(ΣX)) / N 
            intercept = (sumOfY - (slope * sumOfX)) / length;
        }
    }
}
