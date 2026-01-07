using ShopDBProduct.Entities;

namespace ShopDBProduct.Repositories.Implementations
{
    public interface IProductRepository
    {
        // cái chỗ này nó trả về thẳng product luôn
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetDetailByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
        Task<Product> UpdateByIdAsync(Product product);
        Task CreateAsync(Product product);


        Task SaveChangesAsync();
    }
}
