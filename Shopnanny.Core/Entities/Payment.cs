using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopnanny.Core.Entities
{
    public class Payment : BaseEntity
    {
        public decimal TotalAmmount { get; set; }
        public string Reference { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public ICollection<PromoCode> MyProperty { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<PromoCodeUseage> PromoCodeUseages { get; set; }
    }
}
