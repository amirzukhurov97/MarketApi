using AutoMapper;
using MarketApi.DTOs.ProductDTOs;
using MarketApi.Interfacies;
using MarketApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketApi.Services
{
    public class ProductServise(IProductRepository repository, IMapper mapper, IServiceProvider serviceProvider) : IProductServise
    {   
        public Product Add(ProductRequest product)
        {
            var productAdd = new Product
            {
                Id = Guid.NewGuid(),
                Name = product.Name,
                Capacity = product.Capacity,
                Description = product.Description,
                MeasurementId = product.MeasurementId,
                ProductCategoryId = product.ProductCategoryId
            };
            repository.Add(productAdd);
            return productAdd;
        }

        public IEnumerable<ProductResponse> GetAll()
        {
            List<ProductResponse>? responses = new List<ProductResponse>();
            var products = repository.GetAll().Include(pc=>pc.ProductCategory).Include(pm=>pm.Measurement).ToList();
            if (products.Count > 0) {
                foreach (var product in products)
                {
                    var response = new ProductResponse
                    {
                        Name = product.Name,
                        Capacity = product.Capacity,
                        Description = product.Description,
                        MeasurementName = product.Measurement?.Name,
                        ProductCategoryName = product.ProductCategory?.Name

                    };
                    responses.Add(response);
                }
            }
            return responses;
        }

        public Product GetById(Guid id)
        {
            return repository.GetById(id);
        }

        public Product Remove(Guid id)
        {
           var resDelete =  repository.Remove(id);
            return resDelete;
        }
        public Product Update(Guid id, ProductUpdateRequest product)
        {
            var productUpdate = mapper.Map<Product>(product);
            var update = repository.Update(id, productUpdate);
            return update;
        }
    }
}
