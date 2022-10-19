using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Exchange.Public.ExchangeRateData
{
    public class ExchangeRateDataRequest
    {
        public string FromCurrency { get; set; }
        public List<string> ToCurrencies { get; set; }
    }
}
