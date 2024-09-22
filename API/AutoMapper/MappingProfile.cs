using AutoMapper;
using Core.Entities;
using Infrastructure.DTOs;

namespace API.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, GetProductDto>()
                .ForMember(x => x.ProductType, o => o.MapFrom(x => x.ProductType.Name))
                .ForMember(x => x.ProductBrand, o => o.MapFrom(x => x.ProductBrand.Name))
                .ForMember(x => x.ImageUrl, o => o.MapFrom<ProductUrlResolver>());
        }
    }
}
