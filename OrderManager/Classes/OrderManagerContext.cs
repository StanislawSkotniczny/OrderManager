using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using OrderManager.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace OrderManager.Classes
{
    public class OrderManagerContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ORder1> ORder1s { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            

            string Directory1 = Directory.GetParent(Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)).FullName).FullName).FullName;
            string FilePath = Path.Combine(Directory1, "Proj.db3");
            SqliteConnectionStringBuilder builder = new SqliteConnectionStringBuilder();
            builder.DataSource = FilePath;
            string connectionString = builder.ConnectionString;
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(connectionString);
            optionsBuilder.EnableSensitiveDataLogging();
        }


      /*  protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("Customers");
                entityTypeBuilder.HasKey(a => a.Id);
                entityTypeBuilder.Property(a => a.Name);
                entityTypeBuilder.Property(a => a.SecondName);
                entityTypeBuilder.Property(a => a.Email);
            });

            modelBuilder.Entity<Order>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("Orders");
                entityTypeBuilder.HasKey(a => a.Id);
                entityTypeBuilder.Property(a => a.OrderNumber);
                entityTypeBuilder.Property(a => a.OrderDate);
                entityTypeBuilder.Property(a => a.CustomerId);
            });

            modelBuilder.Entity<OrderItem>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("OrderItems");
                entityTypeBuilder.HasKey(a => a.Id);
                entityTypeBuilder.Property(a => a.ProductId);
                entityTypeBuilder.Property(a => a.Quantity);
                entityTypeBuilder.Property(a => a.Order);
                entityTypeBuilder.Property(a => a.Product);
            });

            modelBuilder.Entity<Product>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("Customers");
                entityTypeBuilder.HasKey(a => a.Id);
                entityTypeBuilder.Property(a => a.Name);
                entityTypeBuilder.Property(a => a.Price);
               
            });
        }
      */



    }

   


}
