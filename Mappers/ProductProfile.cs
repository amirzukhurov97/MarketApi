using AutoMapper;
using MarketApi.DTOs.ProductDTOs;
using MarketApi.Models;

namespace MarketApi.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile() {
            CreateMap<Product, ProductDTO>()
                .ReverseMap();
            //CreateMap<ProductDTO, Product>();
        }
    }
}
