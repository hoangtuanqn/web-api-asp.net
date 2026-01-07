namespace ShopDBProduct.Entities
{

    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; } = string.Empty;
        public required string Description { get; set; } = string.Empty;
        public bool Status { get; set; } = false;
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
