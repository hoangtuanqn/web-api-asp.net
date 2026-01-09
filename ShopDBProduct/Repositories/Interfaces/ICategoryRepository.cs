using ShopDBProduct.Entities;

namespace ShopDBProduct.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<Category?> GetByIdDetailAsync(int id);
        Task<Category> CreateAsync(Category category);
        void Update(Category category);
        Task<bool> DeleteAsync(int id);


        Task SaveChangesAsync();
    }
}
