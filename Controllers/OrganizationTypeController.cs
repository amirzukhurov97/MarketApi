﻿using MarketApi.DTOs.OrganizationType;
using MarketApi.DTOs.Product;
using MarketApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Serilog;

namespace MarketApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrganizationTypeController(IGenericService<OrganizationTypeRequest, OrganizationTypeUpdateRequest, OrganizationTypeResponse> organizationTypeServise, ILogger<OrganizationTypeController> logger) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var products = organizationTypeServise.GetAll();
                if (products is null || !products.Any())
                {
                    return NotFound("No OrganizationTypes found.");
                }
                return Ok(products);

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
                var getById = organizationTypeServise.GetById(id);
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

        [HttpPost]
        public ActionResult<string> Create(OrganizationTypeRequest OrganizationTypeRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                Log.Information("In the method Create request => {@request}", OrganizationTypeRequest);
                return organizationTypeServise.Create(OrganizationTypeRequest);
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
                logger.LogInformation($"Deleting OrganizationType with ID: {id} from the database.");
                var resDel = organizationTypeServise.Remove(id);
                return Ok(resDel);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An error occurred while deleting OrganizationType with ID: {id}.");
                throw new Exception(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(OrganizationTypeUpdateRequest organizationTypeUpdate)
        {
            try
            {
                logger.LogInformation($"Updating OrganizationType with ID: {organizationTypeUpdate.Id} in the database.");
                var product = organizationTypeServise.Update(organizationTypeUpdate);
                return Ok(product);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An error occurred while updating OrganizationType with ID: {organizationTypeUpdate.Id}.");
                throw new Exception(ex.Message);
            }
        }
    }
}
