using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsWebService.Database.Entities;

namespace ProductsWebService.Database
{
    public class MockProductDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public MockProductDBContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MockProductsDatabase;Trusted_Connection=True;");
        }
    }
}
