﻿using MarketApi.DTOs.Product;
using MarketApi.DTOs.Purchase;
using MarketApi.DTOs.ReturnOrganization;
using MarketApi.DTOs.Sale;
using MarketApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Serilog;

namespace MarketApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReturnOrganizationController(IGenericService<ReturnOrganizationRequest, ReturnOrganizationUpdateRequest, ReturnOrganizationResponse> service, ILogger<ReturnOrganizationController> logger) : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> Create([FromBody] ReturnOrganizationRequest productRequest)
        {
            try
            {                
                Log.Information("In the method Create request => {@request}", productRequest);
                return service.Create(productRequest);
            }
            catch (SqlException ex)
            {
                Log.Error("SQL Error in Create method: {@ex}", ex);
                return StatusCode(500, $"Database error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Log.Error("Exception in Create method: {@ex}", ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var sales = service.GetAll();
                if (sales is null || !sales.Any())
                {
                    return NotFound("No Sale found.");
                }
                return Ok(sales);

            }
            catch (SqlException ex)
            {
                Log.Error("SQL Error in Create method: {@ex}", ex);
                return StatusCode(500, $"Database error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Log.Error("Exception in Create method: {@ex}", ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var getById = service.GetById(id);
                if (getById is null)
                    return NotFound("You have not data");
                Log.Information("In the method GetById result=>{@getById}", getById);
                return Ok(getById);
            }
            catch (SqlException ex)
            {
                Log.Error("SQL Error in GetById method: {@ex}", ex);
                return StatusCode(500, $"Database error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Log.Error("Exception in GetById method: {@ex}", ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                logger.LogInformation($"Deleting Sale with ID: {id} from the database.");
                var resDel = service.Remove(id);
                return Ok(resDel);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An error occurred while deleting Sale with ID: {id}.");
                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] ReturnOrganizationUpdateRequest saleUpdate)
        {
            try
            {
                logger.LogInformation($"Updating Sale with ID: {saleUpdate.Id} in the database.");
                var product = service.Update(saleUpdate);
                return Ok(product);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An error occurred while updating Sale with ID: {saleUpdate.Id}.");
                throw new Exception(ex.Message);
            }
        }
    }
}
