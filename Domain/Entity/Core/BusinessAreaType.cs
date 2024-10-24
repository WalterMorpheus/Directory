﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity.Core
{
    [Table("business_area_type")]
    public class BusinessAreaType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid AlternateId { get; set; } = Guid.NewGuid();
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
        public ICollection<BusinessArea> BusinessAreas { get; set; }
        public ICollection<BusinessAreaTypeRelationship> ParentRelationships { get; set; }
        public ICollection<BusinessAreaTypeRelationship> ChildRelationships { get; set; }
    }
}
