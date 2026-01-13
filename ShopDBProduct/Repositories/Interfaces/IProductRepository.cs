using ShopDBProduct.Entities;

namespace ShopDBProduct.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {

        //Task<List<Product>> GetAllAsync();
        //Task<Product?> GetDetailByIdAsync(int id);
        //Task<Product> CreateAsync(Product product);
        //Task<bool> DeleteAsync(int id);


        Task SaveChangesAsync();
    }
}
