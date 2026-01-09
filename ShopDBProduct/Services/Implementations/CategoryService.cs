using ShopDBProduct.DTOs.Categories;
using ShopDBProduct.DTOs.Products;
using ShopDBProduct.Entities;
using ShopDBProduct.Repositories.Interfaces;
using ShopDBProduct.Services.Interfaces;

namespace ShopDBProduct.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repo;
        public CategoryService(ICategoryRepository repo)
        {
            _repo = repo;
        }
        public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
        {
            var category = await _repo.CreateAsync(new Category
            {
                Name = dto.Name,
                Description = dto.Description,
                Status = dto.Status,
            });
            await _repo.SaveChangesAsync();
            return MapToDto(category);
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            if (await _repo.DeleteAsync(id) == false)
            {
                throw new ArgumentException($"Không thể xóa danh mục có Id: {id}");
            }

            return true;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var categories = await _repo.GetAllAsync();
            return categories.Select(MapToDto);
        }

        public async Task<CategoryDetailDto?> GetDetailByIdAsync(int id)
        {
            //var category = await _repo.GetByIdAsync(id);
            var category = await _repo.GetByIdAsync(id);
            if (category == null)
            {
                throw new ArgumentException($"Không tìm thấy Category với Id {id}");
            }
            return MapToHasProductDto(category);
        }

        public Task<CategoryDto> UpdateByIdAsync(UpdateProductDto product)
        {
            throw new NotImplementedException();
        }

        private static CategoryDto MapToDto(Category category)
        {
            return new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Status = category.Status,
            };
        }
        private static ProductDto MapProductToDto(Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Image = product.Image,
                Price = product.Price,
                Quantity = product.Quantity,
            };
        }
        private static CategoryDetailDto MapToHasProductDto(Category category)
        {
            return new CategoryDetailDto
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Status = category.Status,
                Products = category.Products.Select(MapProductToDto).ToList()
            };
        }
    }
}
