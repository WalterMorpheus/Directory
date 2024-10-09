using Microsoft.AspNetCore.Identity;

namespace Data.Entity.Auth
{
    public class UserClaim : IdentityUserClaim<int>
    {
        public string AlternateId { get; set; }
    }
}
