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


        }




    }

   


}
