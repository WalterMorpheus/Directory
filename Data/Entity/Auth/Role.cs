using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity.Auth
{
    public class Role : IdentityRole<int>
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AlternateId { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}