using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MyFinance.Infrastructure.CrossCutting.Identity.Model
{
    public class Role : IdentityRole<string>
    {
        public List<UserRole> UserRoles { get; set; }

    }
}
