using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Exchange.Public.ExchangeRate
{
    public class ExchangeRateResponse
    {
        public string FromCurrency { get; set; }
        public DateTime DateOfCurrency { get; set; }
        public List<ExchangeRate> ExchangeRates { get; set; }
    }
    public class ExchangeRate
    {
        public string ToCurrency { get; set; }
        public decimal Value { get; set; }
    }
}
