using ShopDBProduct.DTOs.Products;
using ShopDBProduct.Entities;

namespace ShopDBProduct.Services.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDto>> GetAllAsync();
        public Task<ProductDto?> GetDetailByIdAsync(int id);
        public Task<ProductDto> UpdateByIdAsync(UpdateProductDto product);
        public Task<ProductDto> CreateAsync(CreateProductDto product);
        public Task<bool?> DeleteAsync(int id);
    }
}
