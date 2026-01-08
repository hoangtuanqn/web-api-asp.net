using ShopDBProduct.DTOs.Products;

namespace ShopDBProduct.DTOs.Categories
{
    public class CreateCategoryDto
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public bool Status { get; set; } = false;
    }
}
