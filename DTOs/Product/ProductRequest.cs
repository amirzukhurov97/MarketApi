using MarketApi.DTOs.EntityBase;

namespace MarketApi.DTOs.ProductDTOs
{
    public record ProductRequest : BaseProps
    {
        public double Capacity { get; set; }
        public string Description { get; set; } = string.Empty;
        public Guid MeasurementId { get; set; }
        public Guid ProductCategoryId { get; set; }
    }
}
