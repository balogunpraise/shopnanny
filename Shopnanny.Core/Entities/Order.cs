using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopnanny.Core.Entities
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; } = string.Empty;
        public decimal TotalAmmount { get; set; }
        public Payment Payment { get; set; }
        public string ProcessedByUserId { get; set; } = string.Empty;
        public bool Status { get; set; }

    }
}
