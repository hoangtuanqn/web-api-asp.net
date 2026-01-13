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
        //public async Task<Category> CreateAsync(Category category)
        //{
        //    await _context.Categories.AddAsync(category);
        //    _context.SaveChanges();
        //    return category;
        //}

        //public async Task<bool> DeleteAsync(int id)
        //{
        //    var result = await _context.Categories.Where(c => c.Id == id).ExecuteDeleteAsync();
        //    return result > 0;
        //}

        //public async Task<List<Category>> GetAllAsync()
        //{
        //    var products = await _context.Categories.ToListAsync();
        //    return products;
        //}

        //public async Task<Category?> GetByIdAsync(int id)
        //{
        //    var productsInCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        //    return productsInCategory;
        //}
        public async Task<Category?> GetByIdWithDetailProductAsync(int id)
        {
            var productsInCategory = await _context.Categories.Include(c => c.Products).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            return productsInCategory;
        }

        //public async Task<Category?> GetDetailByIdAsync(int id)
        //{
        //    var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        //    return category;
        //}


        //public void Update(Category category)
        //{
        //    _context.Categories.Update(category);
        //}
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
