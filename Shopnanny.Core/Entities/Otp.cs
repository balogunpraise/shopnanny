using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopnanny.Core.Entities
{
    public class Otp : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
    }
}
