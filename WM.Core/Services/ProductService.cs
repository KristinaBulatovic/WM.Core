using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WM.Core.Entities;
using WM.Core.Models;
using WM.Core.Repository;

namespace WM.Core.Services
{
    public interface IProductService
    {
        public List<ProductModel> GetProductsFromDB();
        public List<ProductModel> GetProductsFromJSON();
        public string AddProduct(ProductModel product);
        public ProductModel GetProductForId(int productId);
        public string EditProduct(ProductModel product);
    }
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public List<ProductModel> GetProductsFromDB()
        {
            var result = _productRepository.GetProducts();
            List<ProductModel> products = _mapper.Map<List<ProductModel>>(result);
            return products;
        }

        public List<ProductModel> GetProductsFromJSON()
        {
            List<ProductModel> products = new List<ProductModel>();
            using (StreamReader r = new StreamReader(@"Store.json"))
            {
                string json = r.ReadToEnd();
                products = JsonConvert.DeserializeObject<List<ProductModel>>(json);
                r.Close();
            }
            return products;
        }

        public string AddProduct(ProductModel product)
        {
            var entity = _mapper.Map<Product>(product);
            var result = _productRepository.AddProduct(entity);
            return result;
        }

        public ProductModel GetProductForId(int productId)
        {
            var result = _productRepository.GetProducts().Where(x => x.Id == productId).FirstOrDefault();
            ProductModel product = _mapper.Map<ProductModel>(result);
            return product;
        }

        public string EditProduct(ProductModel product)
        {
            var entity = _mapper.Map<Product>(product);
            var result = _productRepository.EditProduct(entity);
            return result;
        }
    }
}
