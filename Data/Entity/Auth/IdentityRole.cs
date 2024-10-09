using Microsoft.AspNetCore.Identity;

namespace Data.Entity.Auth
{
    public class IdentityRoleClaim : IdentityRoleClaim<int>
    {
        public string AlternateId { get; set; }
    }
}
