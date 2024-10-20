using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity.Core
{
    [Table("customer_business_area")]
    public class CustomerBusinessArea
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [Required]
        public int BusinessAreaId { get; set; }
        public BusinessArea BusinessArea { get; set; }

    }
}
