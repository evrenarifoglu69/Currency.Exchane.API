using Currency.Exchange.Core.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace Currency.Exchange.Core.DbEntities
{
    public class ExchangeRateEntity : AuditableEntity
    {
        [MaxLength(3), MinLength(3), Required]
        public string FromCurrency { get; set; }
        [MaxLength(3), MinLength(3), Required]
        public string ToCurrency { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
    }
}
