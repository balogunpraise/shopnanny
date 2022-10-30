using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopnanny.Core.Entities
{
    public class CartItem : BaseEntity
    {
        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
