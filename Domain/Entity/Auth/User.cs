﻿using Domain.Entity.Core;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity.Auth
{
    public class User : IdentityUser<int>
    {
        [Required]
        public Guid AlternateId { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public ICollection<UserRole> UserRoles { get; set; }
        public ICollection<UserCustomerApplication> UserCustomerApplications { get; set; }
    }
}
