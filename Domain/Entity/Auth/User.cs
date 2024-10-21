using Domain.Entity.Core;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity.Auth
{
    public class User : IdentityUser<int>
    {
        [Required]
        public Guid AlternateId { get; set; } = Guid.NewGuid();
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UserCustomer> UserCustomers { get; set; }
    }
}
