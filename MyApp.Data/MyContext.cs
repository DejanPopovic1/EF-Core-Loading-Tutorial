using Microsoft.EntityFrameworkCore;
using MyApp.Domain;
using System;

namespace MyApp.Data
{
    public class MyContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=MyAppData")
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name })
                .EnableSensitiveDataLogging();
                //.UseLazyLoadingProxies();
        }
    }
}
