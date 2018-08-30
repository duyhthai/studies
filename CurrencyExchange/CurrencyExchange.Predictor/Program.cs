using System;
using System.IO;
using CurrencyExchange.Core;
using Microsoft.Extensions.Configuration;

namespace CurrencyExchange.Predictor
{
    public class Program
    {
        private static IConfiguration configuration;

        public static void Main()
        {
            // Declare variables
            string openExchangeAppID = Configuration["OpenExchange:AppID"];
            var dateToPredict = new DateTime(2017, 1, 15);
            var lineReader = new ConsoleLineReader();
            bool predictionResult = true;

            // Run program
            Console.WriteLine("Currency Exchange Predictor is running.\n");
            while (predictionResult)
            {
                predictionResult = ExecuteCurrencyExchangePredictor(openExchangeAppID, dateToPredict, lineReader);
            }
        }

        public static IConfiguration Configuration
        {
            get
            {
                if (configuration == null)
                {
                    var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json");
                    configuration = builder.Build();
                }

                return configuration;
            }
        }

        public static bool ExecuteCurrencyExchangePredictor(string openExchangeAppID, DateTime dateToPredict, ConsoleLineReader lineReader)
        {
            // Declare variables
            string fromCurrency;
            string toCurrency;
            double predictedValue;
            string shouldContinue = "N";

            // Get From and To currencies
            Console.WriteLine("Please input 'from' currency and 'to' currency for prediction.");
            Console.Write("From: ");
            fromCurrency = lineReader.ReadLine().ToUpper();
            Console.Write("To: ");
            toCurrency = lineReader.ReadLine().ToUpper();

            // Execute prediction
            Console.WriteLine("Getting data. Please wait...");
            predictedValue = Utilities.PredictCurrencyExchangeRate(openExchangeAppID, fromCurrency, toCurrency, dateToPredict);
            Console.WriteLine($"The predicted currency exchange from {fromCurrency} to {toCurrency} for {dateToPredict.ToString("d/M/yyyy")} is {predictedValue}\n");

            // Ask to continue or not
            Console.Write("Do you want a new prediction? (y/N) ");
            shouldContinue = lineReader.Confirm();
            if (shouldContinue == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
