﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entity.Auth
{
    public class IdentityUserToken : IdentityUserToken<int>
    {
        [Required]
        public Guid AlternateId { get; set; } = Guid.NewGuid();
    }
}
