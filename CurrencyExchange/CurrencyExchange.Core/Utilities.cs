using System;
using System.Linq;
using CurrencyExchange.Core.Api;
using CurrencyExchange.Core.Math;

namespace CurrencyExchange.Core
{
    public static class Utilities
    {
        /// <summary>
        /// Predict currency exchange rate based on last year data.
        /// </summary>
        /// <param name="openExchangeAppID">A valid app ID from Open Exchange Rates</param>
        /// <param name="fromCurrency">Currency to exchange from (3-letter code)</param>
        /// <param name="toCurrency">Currency to exchange to (3-letter code)</param>
        /// <param name="dateToPredict">The date that needs to be predicted.</param>
        /// <returns></returns>
        public static double PredictCurrencyExchangeRate(string openExchangeAppID, string fromCurrency, string toCurrency, DateTime dateToPredict)
        {
            // Get last year rates
            var oxrHelper = new OpenExchangeRates(openExchangeAppID);
            var lastYearRates = oxrHelper.GetYearlyRates(fromCurrency, toCurrency, dateToPredict.AddYears(-1));

            // Get predicted value
            double predictedValue = LinearRegression.PredictCurrencyExchangeRate(
                lastYearRates.Select(r => r.Key).ToArray(), lastYearRates.Select(r => r.Value).ToArray(), dateToPredict.Month);

            return predictedValue;
        }
    }
}
