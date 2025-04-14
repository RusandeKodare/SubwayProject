using AutoMapper;
using subway_project.Server.Models;
using subway_shared.DTOs.OrderDTOs;
using subway_shared.DTOs.ProductDTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductPostDTO, Product>();
        CreateMap<OrderDTO, Order>();
    }
}
