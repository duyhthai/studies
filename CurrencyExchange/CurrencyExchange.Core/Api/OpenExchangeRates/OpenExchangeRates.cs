using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CurrencyExchange.Core.Api
{
    public class OpenExchangeRates
    {
        private string appID;

        public OpenExchangeRates(string appID)
        {
            this.appID = appID;
        }

        /// <summary>
        /// Get currency exchange rates of the appointed date.
        /// </summary>
        /// <param name="date">The date to get exchange rates.</param>
        /// <param name="baseCurrency">The base currency to get exchange rates.</param>
        /// <returns></returns>
        public Rates GetHistoricalData(string date, string baseCurrency = "USD")
        {
            // Call historical api from OXR 
            // https://docs.openexchangerates.org/docs/historical-json
            var response = ApiHelper.ExecuteApi($"https://openexchangerates.org/api/historical/{date}.json?app_id={appID}&base={baseCurrency}");

            if (response != null && response.Content != null)
            {
                try
                {
                    // Convert the result to our object
                    var data = JsonConvert.DeserializeObject<HistoricalResult>(response.Content);

                    if (data != null && data.rates != null)
                    {
                        return data.rates;
                    }
                }
                catch
                {
                    return null;
                }
            }

            return null;
        }

        /// <summary>
        /// Get currency exchange rates in 12 months starting from the appointed date.
        /// </summary>
        /// <param name="fromCurrency">Currency to exchange from (3-letter code)</param>
        /// <param name="toCurrency">Currency to exchange to (3-letter code)</param>
        /// <param name="startDate">The start date to get exchange rates.</param>
        /// <returns></returns>
        public List<KeyValuePair<int, double>> GetYearlyRates(string fromCurrency, string toCurrency, DateTime startDate)
        {
            var yearlyRates = new List<KeyValuePair<int, double>>();
            DateTime dateToGetRates = startDate;

            // Get rates in 12 months
            for (int i = 0; i < 12; i++)
            {
                // Get rates
                var rates = GetHistoricalData(dateToGetRates.ToString("yyyy-MM-dd"), fromCurrency);

                if (rates != null)
                {
                    // Save the month and rate as a key-value pair
                    var toCurrencyRate = typeof(Rates).GetProperty(toCurrency).GetValue(rates);
                    yearlyRates.Add(new KeyValuePair<int, double>(dateToGetRates.Month, (double)toCurrencyRate));

                    // Increase 1 month
                    dateToGetRates = dateToGetRates.AddMonths(1);
                }
                else
                {
                    // Stop when date out of range or any issues with the API
                    break;
                }
            }

            return yearlyRates;
        }
    }
}
