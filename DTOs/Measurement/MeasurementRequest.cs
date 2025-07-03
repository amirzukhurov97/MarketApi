using MarketApi.DTOs.EntityBase;
using MarketApi.Models.Abstract.Entity;

namespace MarketApi.DTOs.Measurement
{
    public record MeasurementRequest : EntityBaseRequest
    {
        public string Name { get; set; } = string.Empty;
    }
}
