using ShopDBProduct.Data;
using ShopDBProduct.Repositories.Interfaces;

namespace ShopDBProduct.Repositories.Implementations
{
    // document: https://viblo.asia/p/04-repository-pattern-va-unit-of-work-trong-net-Ny0VGRwELPA
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IProductRepository Products { get; }
        public ICategoryRepository Categories { get; }
        public IOrderRepository Orders { get; }


        public UnitOfWork(
            AppDbContext context,
            IProductRepository productRepository,
            ICategoryRepository categoryRepository,
            IOrderRepository orderRepository
         )
        {
            _context = context;
            Products = productRepository;
            Categories = categoryRepository;
            Orders = orderRepository;
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
