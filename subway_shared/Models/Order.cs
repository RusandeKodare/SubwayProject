namespace subway_shared.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public List<Product> Products { get; set; } = new();
    }
}
