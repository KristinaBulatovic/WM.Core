using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WM.Core.Services;

namespace WM.Core.Controllers
{
    [Route("api/[controller]")]
    public class ProductController: Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

    }
}
