using MarketApi.DTOs.ProductCategory;
using MarketApi.Infrastructure.Interfacies;
using MarketApi.Models;

namespace MarketApi.Services
{
    public class ProductCategoryService(IProductCategoryRepository repository) : IProductCategoryService
    {
        public ProductCategory Add(ProductCategoryRequest productCategoryRequest)
        {
            if (productCategoryRequest == null)
            {
                throw new ArgumentNullException(nameof(productCategoryRequest), "ProductCategoryRequest cannot be null");
            }
            var productCategory = new ProductCategory
            {
                Id = Guid.NewGuid(),
                Name = productCategoryRequest.Name ?? throw new ArgumentNullException(nameof(productCategoryRequest.Name), "Name cannot be null")
            };
            // Here you would typically call a repository to save the product category
            repository.Add(productCategory);
            return productCategory;

        }

        public IEnumerable<ProductCategory> GetAll()
        {
            var result = repository.GetAll().ToList();
            return result;
        }

        public ProductCategory GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public ProductCategory Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public ProductCategory Update(Guid id, ProductCategoryRequest measurement)
        {
            throw new NotImplementedException();
        }
    }
}
