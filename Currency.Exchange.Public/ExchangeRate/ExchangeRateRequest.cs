using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Exchange.Public.ExchangeRate
{
    public class ExchangeRateRequest
    {
        [Required]
        public string FromCurrency { get; set; }
        public string ToCurrencies { get; set; }
    }
}
