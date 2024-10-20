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
        public int ParentTypeId { get; set; }
        public virtual BusinessAreaType ParentType { get; set; }
        [Required]
        public int ChildTypeId { get; set; }
        public virtual BusinessAreaType ChildType { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        [Required]
        public string CreatedBy { get; set; }
    }
}
