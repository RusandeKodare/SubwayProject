namespace subway_project.Server.Models
{
    public class Sub
    {
        public int Id { get; set; }
        public Order? Order { get; set; }
        public ICollection<SubProduct> SubProducts { get; set; } = [];
    }
}
