using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WM.Core.Models;
using WM.Core.Repository;

namespace WM.Core.Services
{
    public interface IProductService
    {

    }
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
        }
    }
}
