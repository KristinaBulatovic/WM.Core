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
                    Name = "Banana",
                    Description = "Store fresh at 7C",
                    Category = Category.Fruits,
                    Manufacturer = "PACIFIC FRUIT LTD DOO",
                    Supplier = "Maxi",
                    Price = 64.00
                },
                 new Product
                 {
                     Id = 2,
                     Name = "Potato",
                     Description = "White potatoes",
                     Category = Category.Vegetables,
                     Manufacturer = "FRUIT COMPANY DOO",
                     Supplier = "Maxi",
                     Price = 33.00
                 },
                  new Product
                  {
                      Id = 3,
                      Name = "Nutella",
                      Description = "Nutella cream 750g",
                      Category = Category.Sweets,
                      Manufacturer = "DELTA DMD DOO",
                      Supplier = "Maxi",
                      Price = 689.99
                  }
            );

        }
    }
}
