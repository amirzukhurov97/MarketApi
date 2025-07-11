﻿using MarketApi.DTOs.Customer;
using MarketApi.DTOs.Measurement;
using MarketApi.Infrastructure.Interfacies;
using MarketApi.Models;
using MarketApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Serilog;

namespace MarketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(IGenericService<CustomerRequest, CustomerUpdateRequest, CustomerResponse> customerService, ILogger<ProductController> logger) : ControllerBase
    {        

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var customers = customerService.GetAll();
                if (customers is null || !customers.Any())
                {
                    return NotFound("No customers found.");
                }
                return Ok(customers);

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
                var getById = customerService.GetById(id);
                if (getById is null)
                    return NotFound($"No elements by id {id}");
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

        [HttpPost]
        public ActionResult<string> Create(CustomerRequest customerRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                Log.Information("In the method Create request => {@request}", customerRequest);
                return customerService.Create(customerRequest);
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

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {
                logger.LogInformation($"Deleting customer with ID: {id} from the database.");
                var resDel = customerService.Remove(id);
                return Ok(resDel);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An error occurred while deleting customer with ID: {id}.");
                throw new Exception(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(CustomerUpdateRequest customerUpdate)
        {
            try
            {
                logger.LogInformation($"Updating customer with ID: {customerUpdate.Id} in the database.");
                var product = customerService.Update(customerUpdate);
                return Ok(product);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An error occurred while updating customer with ID: {customerUpdate.Id}.");
                throw new Exception(ex.Message);
            }
        }
    }
}
