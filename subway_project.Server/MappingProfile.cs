using AutoMapper;
using subway_project.Server.Models;
using subway_shared.DTOs.OrderDTOs;
using subway_shared.DTOs.ProductDTOs;
using subway_shared.DTOs.SpecialDTOs;
using subway_shared.DTOs.SubDTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductDTO, Product>();
        CreateMap<OrderDTO, Order>()
            .ForMember(dest => dest.Subs, opt => opt.Ignore());
        CreateMap<SubDTO, Sub>();
        CreateMap<SpecialDTO, Specials>();
    }
}
