namespace subway_project.Server.Models
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string? ImageUrl { get; set; } = "images\\no-image-available.jpg";
        public List<Order> Orders { get; set; } = new();
    }
}
