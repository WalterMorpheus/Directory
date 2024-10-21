using Microsoft.AspNetCore.Identity;

namespace Entity
{
    public class Role : IdentityRole<int>
    {
        public string AlternateId { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
