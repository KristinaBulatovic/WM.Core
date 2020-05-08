using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WM.Core.Entities;

namespace WM.Core.Repository
{
    public class StoreDBContext : DbContext
    {
        public StoreDBContext(DbContextOptions<StoreDBContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Bounty chocolate bar",
                    Description = "Bounty has a coconut filling enrobed with milk chocolate",
                    Category = Category.Sweets,
                    Manufacturer = "NELT CO. DOO",
                    Supplier = "IDEA",
                    Price = 69.99
                },
                 new Product
                 {
                     Id = 2,
                     Name = "Banana",
                     Description = "A banana is an elongated, edible fruit – botanically a berry",
                     Category = Category.Fruits,
                     Manufacturer = "PACIFIC FRUIT LTD DOO",
                     Supplier = "MAXI",
                     Price = 119.99
                 },
                  new Product
                  {
                      Id = 3,
                      Name = "Nutella",
                      Description = "Nutella is a chocolate and hazelnut spread",
                      Category = Category.Sweets,
                      Manufacturer = "DELTA DMD DOO",
                      Supplier = "MAXI",
                      Price = 689.99
                  }
            );

        }
    }
}
