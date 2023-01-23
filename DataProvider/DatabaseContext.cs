using CarWash.Api.Models;
using Microsoft.EntityFrameworkCore;


namespace CarWash.Api.Data
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

        public DbSet<Category> Categories  =>Set<Category>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Customer> Customers => Set<Customer>();


        //public DbSet<VW_Category_Product> Category_Product { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{


        //    modelBuilder.Entity<VW_Category_Product>(x =>
        //    x.HasNoKey()
        //    .ToView("VW_Category_Product")
        //    );
        //}


    }
}