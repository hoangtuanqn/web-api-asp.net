namespace ShopDBProduct.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
