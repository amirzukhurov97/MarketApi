using AutoMapper;
using MarketApi.DTOs.ProductCategory;
using MarketApi.Models;

namespace MarketApi.Mappers
{
    public class ProductCategoryProfile : Profile
    {

        public ProductCategoryProfile()
        {
            CreateMap<ProductCategory, ProductCategoryRequest>()
            .ReverseMap();

            CreateMap<ProductCategory, ProductCategoryUpdateRequest>()
                    .ReverseMap();

            CreateMap<ProductCategory, ProductCategoryResponse>()
                .ReverseMap();
        }
    }
}
