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

        public virtual DbSet<Transport> Transports { get; set; }


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

    }

   


}
