using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Data.Entity.Auth
{
    public class UserRole : IdentityUserRole<int>
    {
        [Required]
        public Guid AlternateId { get; set; } = Guid.NewGuid();
        public User User { get; set; }
        public Role Role { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        [Required]
        public string CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}
