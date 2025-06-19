using MarketApi.DTOs.Measurement;
using MarketApi.Infrastructure.Interfacies;
using MarketApi.Models;

namespace MarketApi.Services
{
    public class MeasurementService(IMeasurementRepository repository) : IMeasurementService
    {
        public Measurement Add(MeasurementRequest measurementRequest)
        {
            var measurement = new Measurement
            {
                Id = Guid.NewGuid(),
                Name = measurementRequest.Name ?? throw new ArgumentNullException(nameof(measurementRequest.Name), "Name cannot be null")
            };
            repository.Add(measurement);
            return measurement;
        }

        public IEnumerable<Measurement> GetAll()
        {
            var result = repository.GetAll().ToList();
            return result;
        }

        public Measurement GetById(Guid id)
        {
            return repository.GetById(id);
        }

        public Measurement Remove(Guid id)
        {
            return repository.Remove(id);
        }

        public Measurement Update(Guid id, MeasurementRequest measurement)
        {
            throw new NotImplementedException();
        }

        //public Measurement Update(Guid id, MeasurementRequest measurementRequest)
        //{

        //    var measurement = new Measurement
        //    {
        //        Id = id,
        //        Name = measurementRequest.Name ?? throw new ArgumentNullException(nameof(measurementRequest.Name), "Name cannot be null")
        //    };
        //    repository.Update(measurement);

        //    return measurement;
        //}
    }
}
