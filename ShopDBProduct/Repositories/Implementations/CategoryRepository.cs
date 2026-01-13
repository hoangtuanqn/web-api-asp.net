using Microsoft.EntityFrameworkCore;
using ShopDBProduct.Data;
using ShopDBProduct.Entities;
using ShopDBProduct.Repositories.Interfaces;

namespace ShopDBProduct.Repositories.Implementations
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context): base(context)
        {
            _context = context;
        }
        public async Task<Category?> GetByIdWithDetailProductAsync(int id)
        {
            var productsInCategory = await _context.Categories.Include(c => c.Products).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            return productsInCategory;
        }

    }
}
