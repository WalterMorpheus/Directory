using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Core
{
    [Table("application")]
    public class Application
    {
        [Key]
        public int Id { get; set; }
        public Guid AlternateId { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        [Required]
        public string CreatedBy { get; set; } = "api";
        public DateTime UpdateDate { get; set; } = DateTime.UtcNow;
        public string UpdateBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeleteDate { get; set; }
        public ICollection<CustomerApplication> CustomerApplications { get; set; }
    }
}


