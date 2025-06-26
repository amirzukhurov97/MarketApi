using MarketApi.DTOs.EntityBase;
using MarketApi.Models.Abstract.Entity;

namespace MarketApi.DTOs.Product
{
    public record ProductUpdateRequest : EntityBaseUpdateRequest
    {
        public string Name { get; set; } = string.Empty;
        public double Capacity { get; set; }
        public string Description { get; set; } = string.Empty;
        public Guid MeasurementId { get; set; }
        public Guid ProductCategoryId { get; set; }
    }

}
