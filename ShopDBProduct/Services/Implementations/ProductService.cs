using ShopDBProduct.DTOs.Products;
using ShopDBProduct.Entities;
using ShopDBProduct.Repositories.Interfaces;
using ShopDBProduct.Services.Interfaces;

namespace ShopDBProduct.Services.Implementations
{

    public class ProductService : IProductService
    {
        public readonly IProductRepository _repo;
        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }
        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            var product = await _repo.CreateAsync(new Product
            {
                Name = dto.Name,
                Image = dto.Image,
                Price = dto.Price,
                Quantity = dto.Quantity,
            });
            await _repo.SaveChangesAsync();
            return MapToDto(product);
        }

        public async Task<bool?> DeleteAsync(int id)
        {
            return await _repo.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _repo.GetAllAsync();
            return products.Select(MapToDto);
        }

        public async Task<ProductDto?> GetDetailByIdAsync(int id)
        {
            var product = await _repo.GetDetailByIdAsync(id);
            if (product == null)
            {
                throw new Exception("Product not found! OK =))");
            }
            return MapToDto(product);
        }

        public async Task<ProductDto> UpdateByIdAsync(UpdateProductDto dto)
        {
            var product = await _repo.GetDetailByIdAsync(dto.Id);
            if (product == null)
            {
                throw new Exception("Product not found! OK =))");
            }
            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Quantity = dto.Quantity;
            _repo.Update(product);
            await _repo.SaveChangesAsync();
            return MapToDto(product);
        }

        private static ProductDto MapToDto(Product product)
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
    }
}
