using System.Diagnostics.Metrics;
using MarketApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductCategoryController:ControllerBase
    {
        public static List<ProductCategory> productCategories = new List<ProductCategory>();
        public ProductCategoryController()
        {
            productCategories.Add(new ProductCategory{Name = "Первый" });
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                if (productCategories == null)
                {
                    return NotFound("Don't have elements");
                }
                return Ok(productCategories);
            }
            catch (Exception ex)
            {
                return BadRequest($"Add category Exeption: {ex.Message}");
            }
            
        }

        [HttpPost]
        public IActionResult Post(ProductCategory category)
        {
            try
            {
                var categ = new ProductCategory
                {
                    Name = category.Name
                };
                productCategories.Add(categ);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest($"Add category Exeption: {ex.Message}");
            }            
        }
    }
}
