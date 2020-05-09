using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WM.Core.Models;
using WM.Core.Services;
using WM.Core.ViewModels;

namespace WM.Core.Controllers
{
    [Route("api/[controller]")]
    public class ProductController: Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("GetProductsFromDB")]
        public IActionResult GetProductsFromDB()
        {
            return new OkObjectResult(_productService.GetProductsFromDB());
        }

        [HttpGet("GetProductsFromJSON")]
        public IActionResult GetProductsFromJSON()
        {
            return new OkObjectResult(_productService.GetProductsFromJSON());
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct([FromBody]ProductViewModel product)
        {
            if (product == null)
            {
                return new NoContentResult();
            }
            var model = _mapper.Map<ProductModel>(product);
            return new OkObjectResult(_productService.AddProduct(model));
        }

        [HttpGet("GetProductForId")]
        public IActionResult GetProductForId([FromQuery]int productId)
        {
            return new OkObjectResult(_productService.GetProductForId(productId));
        }

        [HttpPost("EditProduct")]
        public IActionResult EditProduct([FromBody]ProductViewModel product)
        {
            if (product == null)
            {
                return new NoContentResult();
            }
            var model = _mapper.Map<ProductModel>(product);
            return new OkObjectResult(_productService.EditProduct(model));
        }

        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct([FromQuery]int productId)
        {
            return new OkObjectResult(_productService.DeleteProduct(productId));
        }
    }
}
