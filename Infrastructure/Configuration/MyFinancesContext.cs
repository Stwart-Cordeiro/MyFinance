﻿using Entities.Entities;
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
        public DbSet<Contas> Conta { get; set; }
        public DbSet<LogSistema> LogSistemas { get; set; }
        public DbSet<PlanoContas> PlanoConta { get; set; }
        public DbSet<Transacoes> Transacao { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Usuario>().ToTable("AspNetUsers").HasKey(x => x.Id);

            base.OnModelCreating(builder);
        }
    }
}