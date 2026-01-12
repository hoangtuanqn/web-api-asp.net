using ShopDBProduct.Data;
using ShopDBProduct.Repositories.Interfaces;

namespace ShopDBProduct.Repositories.Implementations
{
    // document: https://viblo.asia/p/04-repository-pattern-va-unit-of-work-trong-net-Ny0VGRwELPA
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IProductRepository _productRepository;
        public IOrderRepository _orderRepository;
        public UnitOfWork(AppDbContext context, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
