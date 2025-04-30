namespace subway_project.Server.Models
{
    public class Specials
    {
        public int Id { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; } = [];
        public List<Sub> Subs { get; set; } = new();
    }
}
