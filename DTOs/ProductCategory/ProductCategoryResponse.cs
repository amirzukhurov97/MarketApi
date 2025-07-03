using MarketApi.DTOs.EntityBase;
using MarketApi.Models.Abstract.Entity;

namespace MarketApi.DTOs.ProductCategory
{
    public record ProductCategoryResponse : EntityBaseResponse
    {
        public string Name { get; set; } = string.Empty;
    }
}
