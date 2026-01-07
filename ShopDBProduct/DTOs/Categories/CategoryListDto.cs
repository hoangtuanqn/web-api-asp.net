
namespace ShopDBProduct.DTOs.Categories
{
    public class CategoryListDto
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required string Description { get; set; } = string.Empty;
        public bool Status { get; set; } = false;

    }
}
