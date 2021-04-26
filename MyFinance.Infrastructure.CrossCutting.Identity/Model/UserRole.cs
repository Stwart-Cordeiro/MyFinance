using Microsoft.AspNetCore.Identity;

namespace MyFinance.Infrastructure.CrossCutting.Identity.Model
{
    public class UserRole : IdentityUserRole<string>
    {
        public User User { get; set; }
        public Role Role { get; set; }

    }
}
