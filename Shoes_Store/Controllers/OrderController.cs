using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shoes_Store.Data.Interfaces;
using Shoes_Store.Data.ViewModels;

namespace Shoes_Store.Controllers
{
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        [Route("api/createorders")]
        public async Task<IActionResult> CreateOrder([FromBody]OrderViewModel model)
        {
            var result = await _orderService.CreateOrder(model);
            return Ok(result);
        } 
    }
}