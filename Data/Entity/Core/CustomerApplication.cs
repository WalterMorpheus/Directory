using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity.Core
{
    [Table("customer_application")]
    public class CustomerApplication
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Required]
        [ForeignKey("ApplicationId")]
        public int ApplicationId { get; set; }
        public Application Application { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        [Required]
        public string CreatedBy { get; set; }


    }
}
