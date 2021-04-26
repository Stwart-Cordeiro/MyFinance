using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MyFinance.Infrastructure.CrossCutting.Identity.Model
{
    public class User : IdentityUser<string>
    {
        public List<UserRole> UserRoles { get; set; }

    }
}
