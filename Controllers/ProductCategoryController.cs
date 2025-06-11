using System.Diagnostics.Metrics;
using MarketApi.DTOs.ProductCategory;
using MarketApi.Models;
using MarketApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarketApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductCategoryController(IProductCategoryService categoryService):ControllerBase
    {
        

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var productCategory = categoryService.GetAll();
                if (productCategory == null)
                {
                    return Ok("Don't have elements");
                }
                return Ok(productCategory);
            }
            catch (Exception ex)
            {
                return BadRequest($"Add category Exeption: {ex.Message}");
            }
            
        }

        [HttpPost]
        public IActionResult Post(ProductCategoryRequest category)
        {
            try
            {
                var categ = categoryService.Add(category);
                return Ok(categ);
            }
            catch (Exception ex)
            {
                return BadRequest($"Add category Exeption: {ex.Message}");
            }            
        }
    }
}
