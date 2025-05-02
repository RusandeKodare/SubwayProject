namespace subway_project.Server.Models
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
    }
}
