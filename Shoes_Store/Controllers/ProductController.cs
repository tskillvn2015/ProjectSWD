using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoes_Store.Data.Entities;
using Shoes_Store.Data.Interfaces;
using Shoes_Store.Data.ViewModels;

namespace Shoes_Store.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }        
        [HttpPost]
        [Route("api/create")]
        public async Task<IActionResult> Create([FromBody]CreateProductViewModel model)
        {
            var rs = await _productService.CreateProduct(model);
            return Ok(rs);
        }
    }
}