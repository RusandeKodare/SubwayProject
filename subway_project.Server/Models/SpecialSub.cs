namespace subway_project.Server.Models
{
    public class SpecialSub
    {
        public int Id { get; set; }
        public List<Specials> Specials { get; set; } = [];
        public ICollection<Product> Products { get; set; } = [];
    }
}
