namespace ecommerce_web_api.DTO
{
    public class ProductReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public List<int> OrderIds { get; set; } = new();
    }
}
