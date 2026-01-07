using ShopDBProduct.DTOs.Products;

namespace ShopDBProduct.DTOs.Categories
{
    public class CategoryDetailDto
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required string Description { get; set; } = string.Empty;
        public bool Status { get; set; } = false;
        public ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
