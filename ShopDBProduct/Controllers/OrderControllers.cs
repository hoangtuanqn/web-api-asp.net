using Microsoft.AspNetCore.Mvc;
using ShopDBProduct.Controllers.Base;
using ShopDBProduct.DTOs.Orders;
using ShopDBProduct.Services.Interfaces;

namespace ShopDBProduct.Controllers
{
    [Route("api/v1/orders")]
    public class OrderControllers : BaseApiController
    {
        private readonly IOrderService _orderService;
        public OrderControllers(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto dto)
        {
            var orderId = await _orderService.CreateOrderAsync(dto);
            return Ok(orderId);
        }
    }
}
