using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity.Auth
{
    public class UserRole : IdentityUserRole<int>
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AlternateId { get; set; } 
        public User User { get; set; }
        public Role Role { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        [Required]
        public string CreatedBy { get; set; } = "api";
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}
