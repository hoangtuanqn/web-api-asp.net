using Microsoft.EntityFrameworkCore;
using ShopDBProduct.Data;
using ShopDBProduct.Entities;
using ShopDBProduct.Repositories.Interfaces;

namespace ShopDBProduct.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Product> CreateAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            return product;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            // ExecuteDeleteAsync: thực thi trực tiếp xún DB luôn
            var result = await _context.Products.Where(p => p.Id == id).ExecuteDeleteAsync();
            return result > 0;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            var products = await _context.Products.AsNoTracking().ToListAsync();
            return products;
        }

        async Task<Product?> IProductRepository.GetDetailByIdAsync(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            return product;
        }


        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
