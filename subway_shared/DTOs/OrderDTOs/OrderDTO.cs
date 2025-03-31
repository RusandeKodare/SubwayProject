using subway_shared.DTOs.ProductDTOs;

namespace subway_shared.DTOs.OrderDTOs;

public class OrderDTO
{
	public decimal TotalPrice { get; set; }
	public List<ProductGetDTO> Products { get; set; } = new();
}