namespace subway_project.Server.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string ProductName { get; set; }
        public decimal Price { get; set; }
        public required Category Category { get; set; }
        public string? ImageUrl { get; set; }
        public List<Order> Orders { get; set; } = new();
    }
}
