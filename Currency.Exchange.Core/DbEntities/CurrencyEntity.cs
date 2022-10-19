using Currency.Exchange.Core.BaseEntities;
using System.ComponentModel.DataAnnotations;

namespace Currency.Exchange.Core.DbEntities
{
    public class CurrencyEntity : AuditableEntity
    {
        [MaxLength(3),MinLength(3), Required]
        public string Code { get; set; }
        [MaxLength(100), Required]
        public string Name { get; set; }
    }
}
