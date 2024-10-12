using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity.Auth
{
    public class Role : IdentityRole<int>
    {
        [Required]
        public Guid AlternateId { get; set; } = Guid.NewGuid();
        public ICollection<UserRole> UserRoles { get; set; }
    }
}