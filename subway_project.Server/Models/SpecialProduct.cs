namespace subway_project.Server.Models
{
    public class SpecialProduct
    {
        public int SpecialId { get; set; }
        public Specials Special { get; set; } = null!;

        public int ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }

}
