namespace ShopDBProduct.DTOs.Products
{
    public class UpdateProductDto
    {

        public string? Name { get; set; }
        public string? Image { get; set; }
        public decimal? Price { get; set; } = 0;
        public int? Quantity { get; set; } = 0;
        public int? CategoryId { get; set; }

    }
}
