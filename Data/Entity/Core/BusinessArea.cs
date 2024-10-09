using Data.Entity.Auth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity.Core
{
    [Table("business_area")]
    public class BusinessArea
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string AlternateId { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string Name { get; set; }
        [Required]
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Required]
        [ForeignKey("BusinessAreaTypeId")]
        public int BusinessAreaTypeId { get; set; }
        public BusinessAreaType BusinessAreaType { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        [Required]
        public string CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeleteDate { get; set; }
    }
}
