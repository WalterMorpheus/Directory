using Microsoft.AspNetCore.Identity;

namespace Data.Entity.Auth
{
    public class UserRole : IdentityUserRole<int>
    {
        public string AlternateId { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
