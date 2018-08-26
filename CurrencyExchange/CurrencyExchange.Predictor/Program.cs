using System;
using System.Linq;
using System.IO;
using CurrencyExchange.Core;
using Microsoft.Extensions.Configuration;
using CurrencyExchange.Core.Api;
using CurrencyExchange.Core.Math;
using System.Collections.Generic;

namespace CurrencyExchange.Predictor
{
    public class Program
    {
        public static IConfiguration Configuration { get; set; }

        public static void Main()
        {
            BuildConfiguration();

            Console.WriteLine("Currency Exchange Predictor is running.\n");

            while (true)
            {
                Console.WriteLine("Please input 'from' currency and 'to' currency for prediction.");
                Console.Write("From: ");
                string fromCurrency = Console.ReadLine().ToUpper();
                Console.Write("To: ");
                string toCurrency = Console.ReadLine().ToUpper();

                double predictedValue = PredictCurrencyExchangeRate(fromCurrency, toCurrency, 2017);
                Console.WriteLine($"The predicted currency exchange from {fromCurrency} to {toCurrency} for 15/1/2017 is {predictedValue}\n");
                Console.Write("Press 'Enter' to continue...");
                Console.Read();
            }
        }

        public static double PredictCurrencyExchangeRate(string fromCurrency, string toCurrency, int yearToPredict)
        {
            // Get last year rates
            var oxrHelper = new OpenExchangeRates(Configuration["OpenExchange:AppID"]);
            Console.WriteLine("Getting data. Please wait...");
            Dictionary<long, double> lastYearRates = oxrHelper.GetYearlyRates(fromCurrency, toCurrency, yearToPredict - 1);

            // Get predicted value
            double predictedValue = LinearRegression.PredictCurrencyExchangeRate(
                lastYearRates.Keys.ToArray(), lastYearRates.Values.ToArray(), new DateTime(yearToPredict, 1, 15));

            return predictedValue;
        }

        private static void BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }
    }
}
