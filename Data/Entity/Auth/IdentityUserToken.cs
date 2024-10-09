using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity.Auth
{
    public class IdentityUserToken : IdentityUserToken<int>
    {
        public string AlternateId { get; set; }
    }
}
