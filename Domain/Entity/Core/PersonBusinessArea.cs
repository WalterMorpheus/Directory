using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Core
{
    [Table("person_business_area")]
    public class PersonBusinessArea
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int PersonId { get; set; }
        public Person Person { get; set; }
        [Required]
        public int BusinessAreaId { get; set; }
        public BusinessArea BusinessArea { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        [Required]
        public string CreatedBy { get; set; }
    }
}