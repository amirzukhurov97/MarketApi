using AutoMapper;
using MarketApi.DTOs.ProductDTOs;
using MarketApi.Models;

namespace MarketApi.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile() {
            CreateMap<Product, ProductUpdateRequest>()
                .ReverseMap();
            CreateMap<Product, ProductResponse>()
            .ForMember(dest => dest.MeasurementName, opt => opt.MapFrom(src => src.Measurement.Name))
            .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.ProductCategory.Name));
        }
    }
}
