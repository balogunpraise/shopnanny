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
        public int CityId { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string UserId { get; set; } = string.Empty;

    }
}
