using System;
using Microsoft.EntityFrameworkCore;
using WiredBrainCoffee.Storage.Entities;

namespace WiredBrainCoffee.Storage.Data
{
    public class StorageAppDbContext : DbContext
    {
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Organization> Organizations => Set<Organization>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}
