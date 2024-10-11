using Data.Entity.Core;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity.Auth
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
