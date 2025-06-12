using AutoMapper;
using MarketApi.DTOs.ProductDTOs;
using MarketApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace MarketApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IProductServise productServise) : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var productList = productServise.GetAll();                
                return Ok(productList);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        [HttpGet("{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var productResponse = productServise.GetById(id);                
                return Ok(productResponse);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        [HttpPost]
        public IActionResult Post(ProductRequest productRequest)
        {
            try
            {
                productServise.Add(productRequest);
                return Created("", productRequest);
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
                var resDel = productServise.Remove(id);                
                return Ok(resDel);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }        
        }
        [HttpPut]
        public IActionResult Put(Guid id, ProductUpdateRequest productUpdate) 
        {
            try
            {                
                var product = productServise.Update(id, productUpdate);
                return Ok(product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}