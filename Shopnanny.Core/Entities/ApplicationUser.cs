using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopnanny.Core.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Product>? Products { get; set; }
        public ICollection<Order>? Orders { get; set; }
        //public ICollection<Otp>? Otps { get; set; }
        public ICollection<Address> Addresses { get; set; }
        //public ICollection<PromoCodeUseage>? PromoCodeUseages { get; set; }

    }
}
