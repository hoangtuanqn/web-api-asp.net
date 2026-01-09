namespace ShopDBProduct.DTOs.Products
{
    public class UpdateProductDto
    {
        public int Id { get; set; }

        public required string Name { get; set; }
        public required string Image { get; set; }
        public required decimal Price { get; set; } = 0;
        public required int Quantity { get; set; } = 0;
    }
}
