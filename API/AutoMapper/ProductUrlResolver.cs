using AutoMapper;
using Core.Entities;
using Infrastructure.DTOs;

namespace API.AutoMapper
{
    public class ProductUrlResolver : IValueResolver<Product, GetProductDto, string>
    {
        private readonly IConfiguration configuration;

        public ProductUrlResolver(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Resolve(Product source, GetProductDto destination, string destMember, ResolutionContext context)
        {
            return configuration["ApiUrl"] + source.PictureUrl;
        }
    }
}
