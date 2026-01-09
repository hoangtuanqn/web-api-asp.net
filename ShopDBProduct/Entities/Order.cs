namespace ShopDBProduct.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
