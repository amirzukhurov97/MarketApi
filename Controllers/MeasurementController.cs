using AutoMapper;
using MarketApi.DTOs.Measurement;
using MarketApi.Models;
using MarketApi.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MarketApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeasurementController(IMeasurementService measurementService, ILogger<MeasurementController> logger) : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            logger.LogInformation("Fetching all Measurements from the database.");
            var _measurements = measurementService.GetAll();
            if (_measurements == null)
            {
                return Ok("Don't have elements");
            }
            return Ok(_measurements);
        }

        [HttpPost]
        public IActionResult Post(MeasurementRequest measurementRequest)
        {
            var measurement= measurementService.Add(measurementRequest);
            return Ok(measurement);
        }

        [HttpGet("{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var measurementList = measurementService.GetById(id);
                if (measurementList == null)
                {
                    return BadRequest($"With id ={id} Don't have measurements");
                }
                return Ok(measurementList);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var resDel = measurementService.Remove(id);
                if (resDel == null)
                {
                    return BadRequest();
                }
                return Ok(resDel);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(Guid id, MeasurementRequest measurementUpdate, [FromServices] IMapper mapper)
        {
            try
            {

                var measurement = measurementService.Update(id, measurementUpdate);
                return Ok(measurement);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
