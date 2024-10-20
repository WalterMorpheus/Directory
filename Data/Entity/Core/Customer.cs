using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity.Core
{
    [Table("customer")]
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid AlternateId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        [Required]
        public string CreatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DeleteDate { get; set; }
        public ICollection<CustomerApplication> CustomerApplications { get; set; }
        public ICollection<BusinessArea> BusinessAreas { get; set; }
        public ICollection<CustomerBusinessArea> CustomerBusinessAreas { get; set; }
        public ICollection<UserCustomer> UserCustomers { get; set; }
        public ICollection<Person> People { get; set; }
    }
}
