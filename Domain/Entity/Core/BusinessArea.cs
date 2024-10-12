using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Core
{
    [Table("business_area")]
    public class BusinessArea
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid AlternateId { get; set; } = Guid.NewGuid();
        [Required]
        public string Name { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Required]
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
        public ICollection<BusinessAreaRelationship> ParentRelationships { get; set; }
        public ICollection<BusinessAreaRelationship> ChildRelationships { get; set; }
        public ICollection<CustomerBusinessArea> CustomerBusinessAreas { get; set; }
        public ICollection<PersonBusinessArea> PersonBusinessAreas { get; set; }
    }
}
