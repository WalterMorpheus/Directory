using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Core
{
    [Table("business_area_relationship")]
    public class BusinessAreaRelationship
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ParentBusinessAreaId { get; set; }
        public BusinessArea ParentBusinessArea { get; set; }
        [Required]
        public int ChildBusinessAreaId { get; set; }
        public BusinessArea ChildBusinessArea { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        [Required]
        public string CreatedBy { get; set; }
    }
}
