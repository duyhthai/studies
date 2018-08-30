using System;
using CurrencyExchange.Predictor;

namespace CurrencyExchange.IntegrationTest
{
    public class MockLineReader : ConsoleLineReader
    {
        private string[] currencies = new string[] { "USD", "VND", "CAD", "AED", "SGD" };
        private Random randomIndex = new Random();
        private string loopProgramAfterFinished;

        public MockLineReader(bool loopProgramAfterFinished = true)
        {
            if (loopProgramAfterFinished)
            {
                this.loopProgramAfterFinished = "y";
            }
            else
            {
                this.loopProgramAfterFinished = "N";
            }
        }

        public override string ReadLine()
        {
            return currencies[randomIndex.Next(currencies.Length)];
        }

        public override string Confirm()
        {
            return loopProgramAfterFinished;
        }
    }
}
