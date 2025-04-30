namespace subway_project.Server.Models
{
    public class SubProduct
    {
        public int SubId { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int Quantity { get; set; }
    }
}
