using subway_shared.DTOs.CategoryDTOs;
using subway_shared.DTOs.OrderDTOs;

namespace subway_shared.DTOs.ProductDTOs;

public class ProductGetDTO
{
	public int Id { get; set; }
	public required string Name { get; set; }
	public decimal Price { get; set; }
	public int CategoryId { get; set; }
	public CategoryDTO? Category { get; set; }
	public string ImageUrl { get; set; } = "images\\no-image-available.jpg";
}