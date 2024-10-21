using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity.Auth
{
    public class IdentityRoleClaim : IdentityRoleClaim<int>
    {
        [Required]
        public Guid AlternateId { get; set; } = Guid.NewGuid();
    }
}
