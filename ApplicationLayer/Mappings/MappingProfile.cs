using ApplicationLayer.DTOs;
using AutoMapper;
using Core.Entities;

namespace ApplicationLayer.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}
