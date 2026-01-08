
namespace ShopDBProduct.DTOs.Categories
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public bool Status { get; set; } = false;

    }
}
