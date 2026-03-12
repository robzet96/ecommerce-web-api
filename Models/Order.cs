namespace ecommerce_web_api.Models
{
    public class Order
    {
        public int Id { get; init; }
        public List<Product> Products { get; set; } = new();
        public decimal TotalPrice { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    }
}
