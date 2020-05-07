using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WM.Core.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public string Manufacturer { get; set; }
        public string Supplier { get; set; }
        public double Price { get; set; }
    }

    public enum Category
    {
        Fruits = 0,
        Vegetables = 1,
        Meat = 2,
        Sweets = 3,
        Drink = 4

    }
}
