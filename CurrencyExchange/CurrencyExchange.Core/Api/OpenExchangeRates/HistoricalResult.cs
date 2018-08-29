namespace CurrencyExchange.Core.Api
{
    public class HistoricalResult
    {
        public int timestamp { get; set; }
        public string @base { get; set; }
        public Rates rates { get; set; }
    }
}
