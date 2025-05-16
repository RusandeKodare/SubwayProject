using subway_shared.DTOs.ProductDTOs;
using subway_shared.DTOs.SubDTOs;
using subway_shared.DTOs.SpecialDTOs;

namespace subway_shared.DTOs.OrderDTOs
{
    public class OrderDTO
    {
        public bool TakeAway { get; set; }
        public decimal TotalPrice { get; set; }
        public List<ProductDTO> Products { get; set; } = new();
        public List<SubDTO> Subs { get; set; } = new();
        public List<SpecialDTO> Specials { get; set; } = [];
        public string customerId { get; set; } = null!;
    }
}