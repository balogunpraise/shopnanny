using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopnanny.Core.Entities
{
    public class State : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
