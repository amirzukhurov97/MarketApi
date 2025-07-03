using AutoMapper;
using MarketApi.DTOs.Customer;
using MarketApi.DTOs.Market;
using MarketApi.Models;

namespace MarketApi.Mappers
{
    public class MarketProfile : Profile
    {
        public MarketProfile()
        {
            CreateMap<Market, MarketRequest>()
                .ForMember(cr => cr.ProductId, c => c.MapFrom(c => c.ProductId))
                .ReverseMap();
            CreateMap<Market, MarketUpdateRequest>()
                .ForMember(cr => cr.ProductId, c => c.MapFrom(c => c.ProductId))
                .ReverseMap();
            CreateMap<Market, MarketResponse>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ReverseMap();
        }
    }
}
