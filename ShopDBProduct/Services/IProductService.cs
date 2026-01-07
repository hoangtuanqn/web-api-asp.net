using ShopDBProduct.Entities;

namespace ShopDBProduct.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetAllAsync();
        public Task<Product> GetDetailByIdAsync();
        public Task<Product> DeleteAsync();
        public Task<Product> UpdateByIdAsync();
        public Task<Product> CreateAsync();
    }
}
