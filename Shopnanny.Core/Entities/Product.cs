using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopnanny.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<ProductImage>? ProductImages { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool HotSale { get; set; }
        public int MinOrderQuantity { get; set; }
        public int LowStockQuantity { get; set; }
        public Category Category { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
        public virtual ICollection<Payment>? Payments { get; set; }
        /*public Cart Cart { get; set; }*/
        public virtual ICollection<CartItem> CartItems { get; set; }

    }
}
