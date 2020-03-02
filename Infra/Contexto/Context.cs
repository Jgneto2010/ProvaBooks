using Domain.Entities;
using Infra.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Contexto
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }



        public DbSet<Category> Categoryes { get; set; }
        public DbSet<Product> Products { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new mappingCategory());
            modelBuilder.ApplyConfiguration(new MappingProduct());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // optionsBuilder.UseSqlServer("Server=localhost,1433; Database = BancoTesteDockerS; User ID = sa; Password = MadreTeresa387122;");
        }
    }
}

