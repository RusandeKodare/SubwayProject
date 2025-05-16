namespace subway_project.Server.Models
{
    public class Specials
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public string Description { get; set; } = null!;
        public int SubCategoryId { get; set; }
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; } = "images\\no-image-available.jpg";
        public ICollection<SpecialProduct> SpecialProducts { get; set; } = [];


    }
}
