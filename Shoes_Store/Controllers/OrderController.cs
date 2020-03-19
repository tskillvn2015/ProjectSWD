using Microsoft.AspNetCore.Mvc;
using Shoes_Store.Data.Interfaces;
using Shoes_Store.Data.ViewModels;
using System.Threading.Tasks;

namespace Shoes_Store.Controllers
{
    [ApiController]
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

        [HttpPut]
        [Route("api/deleteorders")]
        public async Task<IActionResult> Delete([FromBody]deleteOrderVMs model)
        {
            var result = await _orderService.DeleteOrder(model);
            return Ok(result);
        }
    }
}