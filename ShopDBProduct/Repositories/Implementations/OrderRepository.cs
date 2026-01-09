using Microsoft.EntityFrameworkCore;
using ShopDBProduct.Data;
using ShopDBProduct.Entities;
using ShopDBProduct.Repositories.Interfaces;

namespace ShopDBProduct.Repositories.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _context;
        public OrderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsysnc(Order order)
        {
            await _context.Orders.AddAsync(order);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
