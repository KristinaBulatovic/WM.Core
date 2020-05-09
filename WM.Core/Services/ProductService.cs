﻿using AutoMapper;
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
        public string AddProductToJSON(ProductModel product);
        public ProductModel GetProductForId(int productId);
        public ProductModel GetProductForIdFromJSON(int productId);
        public string EditProduct(ProductModel product);
        public string EditProductFromJSON(ProductModel product);
        public string DeleteProduct(int productId);
        public string DeleteProductFromJSON(int productId);
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
            var products = ReadingFromJson();
            return products;
        }

        public string AddProduct(ProductModel product)
        {
            var entity = _mapper.Map<Product>(product);
            var result = _productRepository.AddProduct(entity);
            return result;
        }

        public string AddProductToJSON(ProductModel product)
        {
            var products = ReadingFromJson();
            product.Id = products.Count() + 1;
            products.Add(product);
            return WritingInJson(products);
        }

        public ProductModel GetProductForId(int productId)
        {
            var result = _productRepository.GetProducts().Where(x => x.Id == productId).FirstOrDefault();
            ProductModel product = _mapper.Map<ProductModel>(result);
            return product;
        }

        public ProductModel GetProductForIdFromJSON(int productId)
        {
            ProductModel product = ReadingFromJson().Where(x => x.Id == productId).FirstOrDefault();
            return product;
        }

        public string EditProduct(ProductModel product)
        {
            var entity = _mapper.Map<Product>(product);
            var result = _productRepository.EditProduct(entity);
            return result;
        }
        public string EditProductFromJSON(ProductModel product)
        {
            var products = ReadingFromJson();
            ProductModel oldProduct = products.Where(x => x.Id == product.Id).FirstOrDefault();
            products.Remove(oldProduct);
            products.Add(product);
            return WritingInJson(products);
        }

        public string DeleteProduct(int productId)
        {
            var result = _productRepository.DeleteProduct(productId);
            return result;
        }

        public string DeleteProductFromJSON(int productId)
        {
            var products = ReadingFromJson();
            ProductModel product = products.Where(x => x.Id == productId).FirstOrDefault();
            products.Remove(product);
            return WritingInJson(products);
        }

        private List<ProductModel> ReadingFromJson()
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

        private string WritingInJson(List<ProductModel> products)
        {
            string josnProducts = JsonConvert.SerializeObject(products, Formatting.Indented);
            File.WriteAllText(@"Store.json", josnProducts);
            return "Ok";
        }
    }
}
