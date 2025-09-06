using InventoryManagementSystem;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem
{
        public class Context : DbContext
        {
                private readonly string _connectionString;

                public Context(string? connectionString = null)
                {
                        var basePath = AppDomain.CurrentDomain.BaseDirectory;
                        _connectionString = connectionString ?? $"Data Source={Path.Combine(basePath, \"inventory.db\")}";
                }

                public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<InventoryCategory> InventoryCategories { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierOrder> SupplierOrders { get; set; }
        public DbSet<ReturnSupplierOrder> ReturnSupplierOrders { get; set; }
        public DbSet<SupplierProductBill> SupplierProductBills { get; set; }
        public DbSet<ReturnSupplierProduct> ReturnSupplierProducts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<CustomerProductBill> CustomerProductBills { get; set; }
        public DbSet<ReturnCustomerOrder> ReturnCustomerOrder { get; set; }
        public DbSet<ReturnCustomerProduct> ReturnCustomerProducts { get; set; }
        public DbSet<User> Users { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                {
                        optionsBuilder
                                        .UseSqlite(_connectionString);


                        //base.OnConfiguring(optionsBuilder);
                }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

            modelBuilder.Entity<Inventory>().ToTable("Inventories");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Supplier>().ToTable("Suppliers");
            modelBuilder.Entity<Customer>().ToTable("Customers");

            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //	relationship.DeleteBehavior = DeleteBehavior.NoAction;
            //}

            //modelBuilder.Entity<Inventory>().HasData(SampleData.Inventories[0]);
            //modelBuilder.Entity<Inventory>().HasData(SampleData.Inventories[1]);

            //modelBuilder.Entity<Supplier>().HasData(SampleData.Suppliers[0]);
            //modelBuilder.Entity<Supplier>().HasData(SampleData.Suppliers[1]);

            //modelBuilder.Entity<Customer>().HasData(SampleData.Customers[0]);
            //modelBuilder.Entity<Customer>().HasData(SampleData.Customers[1]);

            //modelBuilder.Entity<CustomerBill>().HasData(SampleData.CustomerBill1);
            //modelBuilder.Entity<CustomerBill>().HasData(SampleData.CustomerBill2);



            //base.OnModelCreating(modelBuilder);
        }




    }
}
