using Microsoft.EntityFrameworkCore;
using ShopDBProduct.Entities;
using ShopDBProduct.Repositories.Interfaces;

namespace ShopDBProduct.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly IOrderRepository _context;
        public OrderRepository(IOrderRepository repo)
        {
            _context = repo;
        }
        public async Task AddAsysnc(Order order)
        {
            await _context.AddAsysnc(order);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
