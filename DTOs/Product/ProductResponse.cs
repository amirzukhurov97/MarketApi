using MarketApi.DTOs.EntityBase;
using MarketApi.Models.Abstract.Entity;

namespace MarketApi.DTOs.Product
{
    public record ProductResponse : EntityBaseResponse
    {
        public string Name { get; set; }
        public double Capacity { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? MeasurementName { get; set; }
        public string? ProductCategoryName { get; set; }
    }
}
