using Data.Entity.Core;
using Microsoft.AspNetCore.Identity;

namespace Data.Entity.Auth
{
    public class User : IdentityUser<int>
    {
        public string AlternateId { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UserCustomer> UserCustomers { get; set; }
    }
}
