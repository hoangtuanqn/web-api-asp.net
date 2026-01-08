

namespace ShopDBProduct.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Image { get; set; }
        public required decimal Price { get; set; } = 0;
        public required int Quantity { get; set; } = 0;

        // Foreign Key
        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    } 
}
