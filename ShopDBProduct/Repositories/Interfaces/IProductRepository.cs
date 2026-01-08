using ShopDBProduct.Entities;

namespace ShopDBProduct.Repositories.Interfaces
{
    public interface IProductRepository
    {

        Task<List<Product>> GetAllAsync();
        Task<Product?> GetDetailByIdAsync(int id);
        Task<Product> CreateAsync(Product product);
        void Update(Product product);
        Task<bool> DeleteAsync(int id);


        Task<bool> SaveChangesAsync();
    }
}
