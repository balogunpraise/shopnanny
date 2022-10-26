using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopnanny.Core.Entities
{
    public class PhoneNumber : BaseEntity
    {
        public string Number { get; set; }
        public string Type { get; set; }
        public string UserId { get; set; }
        public bool Status { get; set; }

    }
}
