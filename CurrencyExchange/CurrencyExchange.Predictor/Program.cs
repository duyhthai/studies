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

            DateTime dateToPredict = new DateTime(2017, 1, 15);
            bool predictionResult = true;
            

            Console.WriteLine("Currency Exchange Predictor is running.\n");
            while (predictionResult)
            {
                predictionResult = ExecuteCurrencyExchangePredictor(dateToPredict);
            }
        }

        public static bool ExecuteCurrencyExchangePredictor(DateTime dateToPredict)
        {
            double predictedValue;
            string fromCurrency;
            string toCurrency;

            Console.WriteLine("Please input 'from' currency and 'to' currency for prediction.");
            Console.Write("From: ");
            fromCurrency = Console.ReadLine().Trim().ToUpper();
            Console.Write("To: ");
            toCurrency = Console.ReadLine().Trim().ToUpper();

            predictedValue = PredictCurrencyExchangeRate(fromCurrency, toCurrency, dateToPredict);
            Console.WriteLine($"The predicted currency exchange from {fromCurrency} to {toCurrency} for {dateToPredict.ToString("d/M/yyyy")} is {predictedValue}\n");
            Console.Write("Press 'Enter' to continue...");
            Console.ReadLine();

            return true;
        }

        public static double PredictCurrencyExchangeRate(string fromCurrency, string toCurrency, DateTime dateToPredict)
        {
            // Get last year rates
            var oxrHelper = new OpenExchangeRates(Configuration["OpenExchange:AppID"]);
            Console.WriteLine("Getting data. Please wait...");
            var lastYearRates = oxrHelper.GetYearlyRates(fromCurrency, toCurrency, dateToPredict.AddYears(-1));

            // Get predicted value
            double predictedValue = LinearRegression.PredictCurrencyExchangeRate(
                lastYearRates.Select(r => r.Key).ToArray(), lastYearRates.Select(r => r.Value).ToArray(), dateToPredict.Month);

            return predictedValue;
        }

        internal static void BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }
    }
}
