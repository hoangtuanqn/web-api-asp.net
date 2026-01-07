using ShopDBProduct.DTOs.Products;
using ShopDBProduct.Services.Interfaces;

namespace ShopDBProduct.Services.Implementations
{

    public class ProductService : IProductService
    {
        public Task<ProductDto> CreateAsync(CreateProductDto product)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetDetailByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> UpdateByIdAsync(UpdateProductDto product)
        {
            throw new NotImplementedException();
        }
    }
}
