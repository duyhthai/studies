using System;
using System.IO;
using System.Linq;
using CurrencyExchange.Core.Api;
using CurrencyExchange.Core.Math;
using Microsoft.Extensions.Configuration;

namespace CurrencyExchange.Predictor
{
    public class Program
    {
        public static IConfiguration Configuration { get; set; }

        public static void Main()
        {
            BuildConfiguration();

            // Declare variables
            string openExchangeAppID = Configuration["OpenExchange:AppID"];
            DateTime dateToPredict = new DateTime(2017, 1, 15);
            bool predictionResult = true;

            // Run program
            Console.WriteLine("Currency Exchange Predictor is running.\n");
            while (predictionResult)
            {
                predictionResult = ExecuteCurrencyExchangePredictor(openExchangeAppID, dateToPredict);
            }
        }

        public static bool ExecuteCurrencyExchangePredictor(string openExchangeAppID, DateTime dateToPredict)
        {
            // Declare variables
            string fromCurrency;
            string toCurrency;
            double predictedValue;
            string shouldContinue = "N";

            // Get From and To currencies
            Console.WriteLine("Please input 'from' currency and 'to' currency for prediction.");
            Console.Write("From: ");
            fromCurrency = Console.ReadLine().Trim().ToUpper();
            Console.Write("To: ");
            toCurrency = Console.ReadLine().Trim().ToUpper();

            // Execute prediction
            predictedValue = PredictCurrencyExchangeRate(openExchangeAppID, fromCurrency, toCurrency, dateToPredict);
            Console.WriteLine($"The predicted currency exchange from {fromCurrency} to {toCurrency} for {dateToPredict.ToString("d/M/yyyy")} is {predictedValue}\n");

            // Ask to continue or not
            Console.Write("Do you want a new prediction? (y/N) ");
            shouldContinue = Console.ReadLine();
            if (shouldContinue.Trim().ToLower() == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static double PredictCurrencyExchangeRate(string openExchangeAppID, string fromCurrency, string toCurrency, DateTime dateToPredict)
        {
            // Get last year rates
            var oxrHelper = new OpenExchangeRates(openExchangeAppID);
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
