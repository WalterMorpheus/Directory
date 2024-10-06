using Microsoft.AspNetCore.Identity;

namespace Entity
{
    public class User : IdentityUser<int>
    {
        public string AlternateId { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
