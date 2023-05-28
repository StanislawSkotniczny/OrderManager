using Microsoft.EntityFrameworkCore;
using OrderManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManager.Classes
{
    public class OrderManagerContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
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




    }

   


}
