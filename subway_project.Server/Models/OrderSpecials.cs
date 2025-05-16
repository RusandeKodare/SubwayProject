namespace subway_project.Server.Models
{
    public class OrderSpecials
    {
        public int OrderId { get; set; }
        public int SpecialId { get; set; }
        public Specials? Special { get; set; }
        public int Quantity { get; set; }
    }
}
