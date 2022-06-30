using Application.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.API.Data
{
    public class SqlContext : DbContext
    {
        public DbSet<Contatos> Contato { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=exemploasp;User Id=root;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public Task<int> SaveChangesAsync()
        {
            foreach (var item in ChangeTracker.Entries<Contatos>().Where( entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (item.State == EntityState.Added)
                {
                    item.Property("DataCadastro").CurrentValue = DateTime.Now;
                    item.Property("DataAlteracao").CurrentValue = DateTime.Now;
                    item.Property("IsActive").CurrentValue = true;
                }

                if (item.State == EntityState.Modified)
                {
                    item.Property("DataCadastro").IsModified = false;
                    item.Property("DataAlteracao").CurrentValue = DateTime.Now;
                }
            }
            return base.SaveChangesAsync();
        }
    }
}
