using Microsoft.EntityFrameworkCore;
using ShopDBProduct.Data;
using ShopDBProduct.Entities;
using ShopDBProduct.Repositories.Interfaces;
using System.Threading.Tasks;

namespace ShopDBProduct.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            _context.Category.Add(category);
            return category;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var result = await _context.Category.Where(c => c.Id == id).ExecuteDeleteAsync();
            return result > 0;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            var products = await _context.Category.AsNoTracking().ToListAsync();
            return products;
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            var product = await _context.Category.FirstOrDefaultAsync(c => c.Id == id);
            return product;
        }

        public async Task<Category?> GetByIdWithProductsAsync(int id)
        {
            var productsInCategory = await _context.Category.Include(c => c.Products).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            return productsInCategory;
        }

        public async Task<Category?> GetDetailByIdAsync(int id)
        {
            var category = await _context.Category.FirstOrDefaultAsync(c => c.Id == id);
            return category;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Category category)
        {
            _context.Category.Update(category);
        }
    }
}
