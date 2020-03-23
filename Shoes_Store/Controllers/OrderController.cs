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
        [Route("api/order")]
        public async Task<IActionResult> CreateOrder([FromBody]createOrderViewModel model)
        {
            var result = await _orderService.CreateOrder(model);
            return Ok(result);
        }

        [HttpDelete]
        [Route("api/order")]
        public async Task<IActionResult> Delete([FromBody]deleteOrderVMs model)
        {
            var result = await _orderService.DeleteOrder(model);
            return Ok(result);
        }

        [HttpPut]
        [Route("api/order")]
        public async Task<IActionResult> Update([FromBody]updateOrderViewModel model)
        {
            var result = await _orderService.UpdateOrder(model);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/orders")]
        public async Task<IActionResult> GetOrderByName([FromQuery]searchOrderViewModel model)
        {
            var result = await _orderService.GetAllOrder(model);
            return Ok(result);
        }
    }
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderdetailService;
        public OrderDetailController(IOrderDetailService orderdetailService)
        {
            _orderdetailService = orderdetailService;
        }
        [HttpPost]
        [Route("api/orderdetail")]
        public async Task<IActionResult> CreateOrder([FromBody]createOrderDetailViewModel model)
        {
            var result = await _orderdetailService.CreateOrderDetail(model);
            return Ok(result);
        }

        [HttpDelete]
        [Route("api/orderdetail")]
        public async Task<IActionResult> Delete([FromBody]deleteOrderDetailViewModel model)
        {
            var result = await _orderdetailService.DeleteOrderDetail(model);
            return Ok(result);
        }

        [HttpPut]
        [Route("api/orderdetail")]
        public async Task<IActionResult> Update([FromBody]updateOrderDetailViewModel model)
        {
            var result = await _orderdetailService.UpdateOrderDetail(model);
            return Ok(result);
        }

        [HttpGet]
        [Route("api/orderdetails")]
        public async Task<IActionResult> GetOrderByName([FromQuery]searchOrderDetailViewModel model)
        {
            var result = await _orderdetailService.GetAllOrderDetail(model);
            return Ok(result);
        }
    }
}