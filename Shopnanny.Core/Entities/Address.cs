using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopnanny.Core.Entities
{
    public class Address : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string StreetName { get; set; } = string.Empty;
        public bool IsShippingAddress { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int StateId { get; set; }
        public State State { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; }

    }
}
