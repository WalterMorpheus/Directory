using Data.Entity.Auth;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity.Core
{
    [Table("business_area_type_relationship")]
    public class BusinessAreaTypeRelationship
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int BusinessAreaTypeParentId { get; set; }
        public virtual BusinessAreaType BusinessAreaTypeParent { get; set; }
        [Required]
        public int BusinessAreaTypeChildId { get; set; }
        public virtual BusinessAreaType BusinessAreaTypeChild { get; set; }
  
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        [Required]
        public string CreatedBy { get; set; }
    }
}
