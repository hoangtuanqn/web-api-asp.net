using ShopDBProduct.DTOs.Orders;

namespace ShopDBProduct.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<int> CreateOrderAsync(CreateOrderDto dto);
    }
}
