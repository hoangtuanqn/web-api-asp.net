using ShopDBProduct.DTOs.Categories;
using ShopDBProduct.DTOs.Products;

namespace ShopDBProduct.Services.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryDto>> GetAllAsync();
        public Task<CategoryDto?> GetDetailByIdAsync(int id);
        public Task<CategoryDto> UpdateByIdAsync(UpdateProductDto product);
        public Task<CategoryDto> CreateAsync(CreateCategoryDto product);
        public Task<bool?> DeleteAsync(int id);
    }
}
