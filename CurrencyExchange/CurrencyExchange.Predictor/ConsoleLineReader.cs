using System;

namespace CurrencyExchange.Predictor
{
    public class ConsoleLineReader
    {
        public virtual string ReadLine()
        {
            return Console.ReadLine().Trim();
        }

        public virtual string Confirm()
        {
            return ReadLine().ToLower();
        }
    }
}
