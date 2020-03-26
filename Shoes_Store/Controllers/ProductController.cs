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
        [Route("api/showProductDetail")]
        public async Task<IActionResult> ShowProductDetail([FromBody]ShowProductDetailViewModel model)
        {
            var rs = await _productService.ShowProductDetail(model);
            return Ok(rs);
        }
        [HttpPost]
        [Route("api/create")]
        public async Task<IActionResult> Create([FromBody]CreateProductViewModel model)
        {
            var rs = await _productService.CreateProduct(model);
            return Ok(rs);
        }

        [HttpPut]
        [Route("api/update")]
        public async Task<IActionResult> Update([FromBody]UpdateProductViewModel model)
        {
            var rs = await _productService.UpdateProduct(model);
            return Ok(rs);
        }

        [HttpPut]
        [Route("api/delete")]
        public async Task<IActionResult> Delete([FromBody]DeleteProductViewModel model)
        {
            var rs = await _productService.DeleteProduct(model);
            return Ok(rs);
        }

        [HttpGet]
        [Route("api/products")]
        public async Task<IActionResult> getProductPagging([FromQuery]SearchProductViewModel model)
        {
            var rs = await _productService.getProductPagging(model);
            return Ok(rs);
        }
    }
}