
namespace ShopDBProduct.DTOs.Categories
{
    public class UpdateCategoryDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? Status { get; set; } = false;
    }
}
