using AutoMapper;
using MarketApi.DTOs.ProductDTOs;
using MarketApi.Interfacies;
using MarketApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketApi.Services
{
    public class ProductServise(IProductRepository repository, IMapper mapper, IServiceProvider serviceProvider) : IProductServise
    {   
        public Product Add(DTOs.ProductDTOs.ProductRequest product)
        {
            try
            {
                var productExists = repository.GetAll().Any(p => p.Name == product.Name && p.Capacity == product.Capacity && p.MeasurementId == product.MeasurementId && p.ProductCategoryId == product.ProductCategoryId);
                if (productExists)
                {
                    throw new Exception("Product already exists with the same name, capacity, measurement, and category.");
                }
                var productAdd = new Product
                {
                    Id = Guid.NewGuid(),
                    Name = product.Name,
                    Capacity = product.Capacity,
                    Description = product.Description,
                    MeasurementId = product.MeasurementId,
                    ProductCategoryId = product.ProductCategoryId
                };
                //var productAdd = mapper.Map<Product>(product);
                repository.Add(productAdd);
                return productAdd;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        public IEnumerable<ProductResponse> GetAll()
        {
            List<ProductResponse>? responses = new List<ProductResponse>();
            var products = repository.GetAll().Include(pc=>pc.ProductCategory).Include(pm=>pm.Measurement).ToList();
            if (products.Count > 0) {
                foreach (var product in products)
                {
                    var response = mapper.Map<ProductResponse>(product);
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
