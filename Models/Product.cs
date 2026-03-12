namespace ecommerce_web_api.Models
{
    public class Product
    {
        public int Id { get; init; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public List<Order> Orders { get; set; } = new();
    }
}
