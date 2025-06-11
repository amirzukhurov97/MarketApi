
using MarketApi.DTOs.ProductCategory;
using MarketApi.Models;

namespace MarketApi.Services
{
    public interface IProductCategoryService
    {
        IEnumerable<ProductCategory> GetAll();
        ProductCategory GetById(Guid id);
        ProductCategory Add(ProductCategoryRequest measurement);
        ProductCategory Remove(Guid id);
        ProductCategory Update(Guid id, ProductCategoryRequest measurement);
    }

   
}
