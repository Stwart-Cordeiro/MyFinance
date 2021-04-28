using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration
{
    public class MyFinancesContext : IdentityDbContext<Usuario>
    {
        public MyFinancesContext(DbContextOptions<MyFinancesContext> options) : base(options)
        {
            
        }

        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Usuario>().ToTable("AspNetUsers").HasKey(x => x.Id);

            base.OnModelCreating(builder);
        }
    }
}