using Microsoft.EntityFrameworkCore;
using Models;

namespace DataProvider
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions op) : base(op)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=MyDB.db");
        //}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Receipt> Receipts { get; set; }


    }
}