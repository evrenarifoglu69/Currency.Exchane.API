namespace Currency.Exchange.Public.ExchangeRateData
{
    public class ExchangeRateDataResponse
    {
        public string @base { get; set; }
        public string date { get; set; }
        public Dictionary<string,decimal> rates { get; set; }
        public bool success { get; set; }
        public int timestamp { get; set; }
    }
}
