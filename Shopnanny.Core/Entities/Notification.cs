using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopnanny.Core.Entities
{
    public class Notification : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string UserID { get; set; } = string.Empty;
        public string SenderUserName { get; set; } = string.Empty;
        public bool IsRead { get; set; }
        public ApplicationUser User { get; set; }
    }
}
