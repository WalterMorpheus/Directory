using Microsoft.AspNetCore.Identity;

namespace Data.Entity.Auth
{
    public class UserLogin : IdentityUserLogin<int>
    {
        public string AlternateId { get; set; }
    }
}
