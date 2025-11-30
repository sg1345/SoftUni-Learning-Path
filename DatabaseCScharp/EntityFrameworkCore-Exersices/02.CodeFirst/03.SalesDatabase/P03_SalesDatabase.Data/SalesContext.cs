using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext() { }

        public SalesContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=SalesDB;Trusted_Connection=True;Encrypt=False;");
        }
    }
}