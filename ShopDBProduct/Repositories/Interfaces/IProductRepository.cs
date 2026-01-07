using ShopDBProduct.Entities;
using ShopDBProduct.Migrations;

namespace ShopDBProduct.Repositories.Interfaces
{
    public interface IProductRepository
    {
        // cái chỗ này nó trả về thẳng product luôn
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetDetailByIdAsync(int id);
        Task<Product> CreateAsync(Product product);
        void Update(Product product);
        Task<bool> DeleteAsync(int id);


        Task<bool> SaveChangesAsync();
    }
}
