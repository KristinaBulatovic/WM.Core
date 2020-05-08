using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WM.Core.Models;
using WM.Core.Repository;

namespace WM.Core.Services
{
    public interface IProductService
    {
        public List<ProductModel> GetProductsFromDB();
        public List<ProductModel> GetProductsFromJSON();
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
    }
}
