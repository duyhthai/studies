using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace CurrencyExchangePredictor
{
    public class Program
    {
        public static IConfiguration Configuration { get; set; }

        public static void Main(string[] args)
        {
            BuildConfiguration();

            Console.WriteLine("Hello World!");
            Console.WriteLine($"OpenExchange app id: {Configuration["OpenExchange:AppID"]}");
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
