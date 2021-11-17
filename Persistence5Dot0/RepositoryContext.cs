using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence5Dot0.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence5Dot0
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.ApplyConfiguration(new OwnerConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Account> Accounts { get; set; }
    }
}
