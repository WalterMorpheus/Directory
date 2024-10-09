using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Data.Entity.Auth;

namespace Data.Entity.Core
{
    [Table("user_customer")]
    public class UserCustomer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        [Required]
        public string CreatedBy { get; set; }
    }
}
