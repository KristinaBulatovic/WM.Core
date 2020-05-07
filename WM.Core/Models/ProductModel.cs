using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WM.Core.Entities;

namespace WM.Core.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public string Manufacturer { get; set; }
        public string Supplier { get; set; }
        public double Price { get; set; }
    }
}
