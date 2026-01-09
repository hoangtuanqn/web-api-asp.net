using ShopDBProduct.Data;
using ShopDBProduct.DTOs.Orders;
using ShopDBProduct.Entities;
using ShopDBProduct.Repositories.Interfaces;
using ShopDBProduct.Services.Interfaces;

namespace ShopDBProduct.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IProductService _productService;
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppDbContext _context;
        public OrderService(
            IProductService productService,
            IOrderRepository orderRepository,
            IUnitOfWork unitOfWork,
            AppDbContext context
            )
        {
            _productService = productService;
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _context = context;
        }
        public async Task<int> CreateOrderAsync(CreateOrderDto dto)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {

                var order = new Order();
                decimal total = 0;
                foreach (var item in dto.Items)
                {
                    var product = await _productService.GetDetailByIdAsync(item.ProductId);
                    if (product == null)
                        throw new KeyNotFoundException($"Không tìm thấy product có id {item.ProductId}");

                    product.Quantity -= item.Quantity;
                    var orderItem = new OrderItem
                    {
                        ProductId = product.Id,
                        ProductName = product.Name,
                        Price = product.Price,
                        Quantity = item.Quantity,
                    };
                    order.Items.Add(orderItem);
                    total += product.Price * item.Quantity;
                }

                order.Price = total;
                await _orderRepository.AddAsysnc(order);
                await _unitOfWork.SaveChangeAsync();
                await transaction.CommitAsync();
                return order.Id;
            }
            catch
            {
                await transaction.CommitAsync();
                throw;
            }
        }
    }
}
