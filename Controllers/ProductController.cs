using AutoMapper;
using MarketApi.DTOs.ProductDTOs;
using MarketApi.Interfacies;
using MarketApi.Models;
using MarketApi.Repositories;
using MarketApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarketApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IProductServise productServise) : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var productList = productServise.GetAll();
                if (productList == null)
                {
                    return BadRequest("Don't have products");
                }
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
                var productList = productServise.GetById(id);
                if (productList==null)
                {
                    return BadRequest($"With id ={id} Don't have products");
                }
                ProductResponse? productResponse = new ProductResponse
                {
                    Name = productList.Name,
                    Capacity = productList.Capacity,
                    Description = productList.Description,
                    MeasurementName = productList.Measurement?.Name,
                    ProductCategoryName = productList.ProductCategory?.Name
                };
                return Ok(productResponse);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        [HttpPost]
        public IActionResult Post(ProductRequest productRequest, [FromServices] IMapper _mapper)
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
                if(resDel == null)
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
        public IActionResult Put(Guid id, ProductUpdateRequest prod, [FromServices] IMapper mapper) 
        {
            try
            {
                
                var product = productServise.Update(id, prod);
                return Ok(product);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}