using AutoMapper;
using MarketApi.DTOs.ProductDTOs;
using MarketApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace MarketApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IProductServise productServise, ILogger<ProductController> logger) : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                logger.LogInformation("Fetching all products from the database.");
                var productList = productServise.GetAll();                
                return Ok(productList);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while fetching products.");
                throw new Exception(ex.Message);
            }
            
        }
        [HttpGet("{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                logger.LogInformation($"Fetching product with ID: {id} from the database.");
                var productResponse = productServise.GetById(id);                
                return Ok(productResponse);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An error occurred while fetching product with ID: {id}.");
                throw new Exception(ex.Message);
            }            
        }

        [HttpPost]
        public IActionResult Post(ProductRequest productRequest)
        {
            try
            {
                logger.LogInformation("Adding a new product to the database.");
                productServise.Add(productRequest);
                return Created("", productRequest);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while adding a new product.");
                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            try
            {                
                logger.LogInformation($"Deleting product with ID: {id} from the database.");
                var resDel = productServise.Remove(id);                
                return Ok(resDel);

            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An error occurred while deleting product with ID: {id}.");
                throw new Exception(ex.Message);
            }        
        }
        [HttpPut]
        public IActionResult Put(Guid id, ProductUpdateRequest productUpdate) 
        {
            try
            {        
                logger.LogInformation($"Updating product with ID: {id} in the database.");
                var product = productServise.Update(id, productUpdate);
                return Ok(product);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"An error occurred while updating product with ID: {id}.");
                throw new Exception(ex.Message);
            }
        }
    }
}