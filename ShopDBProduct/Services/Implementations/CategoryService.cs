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
            //var category = await _repo.CreateAsync(new Category
            //{
            //    Name = dto.Name,
            //    Description = dto.Description,
            //    Status = dto.Status,
            //});
            var category = await _repo.AddAsync(new Category
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
            //if (await _repo.DeleteAsync(id) == false)
            //{
            //    throw new KeyNotFoundException($"Không thể xóa danh mục có Id: {id}");
            //}
            await _repo.DeleteAsync(id);

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
                throw new KeyNotFoundException($"Không tìm thấy Category với Id {id}");
            }
            return MapToHasProductDto(category);
        }

        public async Task<CategoryDto> UpdateByIdAsync(int id, UpdateCategoryDto dto)
        {
            var category = await _repo.GetByIdAsync(id);
            if (category == null)
            {
                throw new KeyNotFoundException($"Không tìm thấy Category với Id {id}");
            }
            if (dto.Name != null) category.Name = dto.Name;
            if (dto.Description != null) category.Description = dto.Description;
            if (dto.Status.HasValue) category.Status = dto.Status.Value;
            await _repo.SaveChangesAsync();
            return MapToDto(category);
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
