﻿
using MarketApi.DTOs.Product;
using MarketApi.DTOs.ProductCategory;
using MarketApi.Models;
using MarketApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Serilog;
using System.Diagnostics.Metrics;

namespace MarketApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductCategoryController(IGenericService<ProductCategoryRequest, ProductCategoryUpdateRequest, ProductCategoryResponse> productCategoryServise, ILogger<ProductCategoryController> logger):ControllerBase
    {
        

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var productCategories = productCategoryServise.GetAll();
                if (productCategories is null || !productCategories.Any())
                {
                    return NotFound("No productCategories found.");
                }
                return Ok(productCategories);
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

        [HttpPost]
        public ActionResult<string> Create(ProductCategoryRequest productRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                Log.Information("In the method Create request => {@request}", productRequest);
                return productCategoryServise.Create(productRequest);
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
                var getById = productCategoryServise.GetById(id);
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
                logger.LogInformation($"Deleting product with ID: {id} from the database.");
                var resDel = productCategoryServise.Remove(id);
                return Ok(resDel);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An error occurred while deleting product with ID: {id}.");
                throw new Exception(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(ProductCategoryUpdateRequest productUpdate)
        {
            try
            {
                logger.LogInformation($"Updating product with ID: {productUpdate.Id} in the database.");
                var product = productCategoryServise.Update(productUpdate);
                return Ok(product);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An error occurred while updating product with ID: {productUpdate.Id}.");
                throw new Exception(ex.Message);
            }
        }
    }
}
