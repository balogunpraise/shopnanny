using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopnanny.Core.Entities
{
    public class Cart : BaseEntity
    {
        public string UserID { get; set; } = string.Empty;
        public ICollection<CartItem>? CartItems { get; set; }
    }
}
