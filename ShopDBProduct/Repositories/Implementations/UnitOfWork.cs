using Microsoft.EntityFrameworkCore.Storage;
using ShopDBProduct.Data;
using ShopDBProduct.Repositories.Interfaces;
using ShopDBProduct.Services.Implementations;

namespace ShopDBProduct.Repositories.Implementations
{
    // document: https://viblo.asia/p/04-repository-pattern-va-unit-of-work-trong-net-Ny0VGRwELPA
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IDbContextTransaction? _transaction;

        private ICategoryRepository? _categoryRepository;
        private IProductRepository? _productRepository;
        private IOrderRepository? _orderRepository;


        public ICategoryRepository Categories => _categoryRepository ??= new CategoryRepository(_context);
        public IProductRepository Products => _productRepository ??= new ProductRepository(_context);
        public IOrderRepository Orders => _orderRepository ??= new OrderRepository(_context);

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }


        public async Task BeginTransaction()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task RollBackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
            }
        }

        // Lưu vô ram
        public async Task<int> SaveChangeAsync()
        {
            return await _context.SaveChangesAsync();
        }

        // Chốt hạ xuống DB
        public async Task CommitAsync()
        {
            try
            {
                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                }
            }
            catch
            {
                await RollBackAsync();
            }
            finally
            {
                if (_transaction != null)
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
