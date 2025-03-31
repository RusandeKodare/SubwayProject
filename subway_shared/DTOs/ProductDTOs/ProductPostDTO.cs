namespace subway_shared.DTOs.ProductDTOs;

public class ProductPostDTO
{
	public required string Name { get; set; }
	public decimal Price { get; set; }
	public int CategoryId { get; set; }
	public string ImageUrl { get; set; } = "images\\no-image-available.jpg";
}