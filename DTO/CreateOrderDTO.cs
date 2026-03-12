namespace ecommerce_web_api.DTO
{
    public class CreateOrderDTO
    {
        public List<int> ProductIds { get; set; } = new();
        public DateTime OrderDate { get; set; }
    }
}
