using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopnanny.Core.Entities
{
    public class ProductImage : BaseEntity
    {
        public Product Product { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
