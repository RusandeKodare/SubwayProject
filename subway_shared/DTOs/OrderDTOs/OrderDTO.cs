using subway_shared.DTOs.ProductDTOs;

namespace subway_shared.DTOs.OrderDTOs;

public class OrderDTO
{
	public bool TakeAway { get; set; }
	public decimal TotalPrice { get; set; }
	public List<ProductPostDTO> Products { get; set; } = new();
	public string customerId { get; set; } = null!;
}