using MarketApi.DTOs.Measurement;
using MarketApi.Models;

namespace MarketApi.Services
{
    public interface IMeasurementService
    {
        IEnumerable<Measurement> GetAll();
        Measurement GetById(Guid id);
        Measurement Add(MeasurementRequest measurement);
        Measurement Remove(Guid id);
        Measurement Update(Guid id, MeasurementRequest measurement);
    }
}
