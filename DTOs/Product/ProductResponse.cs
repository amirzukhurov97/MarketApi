using MarketApi.DTOs.EntityBase;

namespace MarketApi.DTOs.ProductDTOs
{
    public record ProductResponse : BaseProps
    {
        public Guid Id { get; set; }
        public double Capacity { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? MeasurementName { get; set; }
        public string? ProductCategoryName { get; set; }
    }
}
