using MarketApi.DTOs.EntityBase;
using MarketApi.Models.Abstract.Entity;

namespace MarketApi.DTOs.Measurement
{
    public record MeasurementResponse : EntityBaseResponse
    {
        public string Name { get; set; } = string.Empty;
    }
}
