using MarketApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeasurementController : ControllerBase
    {
        public static List<Measurement> _measurements = new();
        public MeasurementController() {
            _measurements.Add(new Measurement {Name = "kg" });
        }

        [HttpGet]
        public IActionResult Get() {
            if (_measurements == null)
            {
                return Ok("Don't have elements");
            }
            return Ok(_measurements);
        }

        [HttpPost]
        public Task<Measurement> Post(Measurement measurement)
        {
            var measure = new Measurement
            {
                Name = measurement.Name
            };
            _measurements.Add(measure);
            return Task.FromResult(measure);
        }
    }
}
