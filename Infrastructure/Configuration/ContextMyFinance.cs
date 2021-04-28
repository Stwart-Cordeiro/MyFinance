using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class ContextMyFinanceContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(x => x.Id);

            base.OnModelCreating(builder);
        }
    }
}