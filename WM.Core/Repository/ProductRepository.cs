using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WM.Core.Entities;

namespace WM.Core.Repository
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetProducts();
        public int AddProduct(Product product);
        public int EditProduct(Product product);
        public int DeleteProduct(int productId);
    }
    public class ProductRepository : IProductRepository
    {
        private readonly StoreDBContext _storeDBContext;
        public ProductRepository(StoreDBContext storeDBContext)
        {
            _storeDBContext = storeDBContext;
        }

        public IEnumerable<Product> GetProducts()
        {
            return _storeDBContext.Products;
        }

        public int AddProduct(Product product)
        {
            _storeDBContext.Add(product);
            return _storeDBContext.SaveChanges();
        }

        public int EditProduct(Product product)
        {
            _storeDBContext.Update(product);
            return _storeDBContext.SaveChanges();
        }

        public int DeleteProduct(int productId)
        {
            Product product = _storeDBContext.Products.Where(x => x.Id == productId).FirstOrDefault();
            _storeDBContext.Remove(product);
            return _storeDBContext.SaveChanges();
        }

    }
}
