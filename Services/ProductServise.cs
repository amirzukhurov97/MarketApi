using AutoMapper;
using Azure;
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
            try
            {
                var productExists = repository.GetAll().Any(p => p.Name == product.Name && p.Capacity == product.Capacity && p.MeasurementId == product.MeasurementId && p.ProductCategoryId == product.ProductCategoryId);
                if (productExists)
                {
                    throw new Exception("Product already exists with the same name, capacity, measurement, and category.");
                }
                var productAdd = mapper.Map<Product>(product);
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
            else
            {
                throw new Exception("No products found.");
            }
            return responses;
        }

        public IEnumerable<ProductResponse> GetById(Guid id)
        {
            List<ProductResponse>? response = new List<ProductResponse>();
            var products = repository.GetAll().Where(p=>p.Id==id).Include(pc => pc.ProductCategory).Include(pm => pm.Measurement).ToList();
            if (products == null)
            {
                throw new Exception($"Product with id {id} not found.");
            }
            foreach (var product in products)
            {
                var productResponse = mapper.Map<ProductResponse>(product);
                response.Add(productResponse);
            }
            
            return response;
        }

        public Product Remove(Guid id)
        {
            var resDelete =  repository.Remove(id);
            if (resDelete == null)
            {
                throw new Exception($"Product with id {id} not found.");
            }
            return resDelete;
        }
        public ProductResponse Update(Guid id, ProductResponse product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "ProductUpdateRequest cannot be null");
            }
            var existingProduct = repository.GetById(id);
            if (existingProduct == null) 
            {
                throw new Exception($"Product with id {id} not found.");
            }
            else
            {
                var productUpdate = mapper.Map<Product>(product);
                var update = repository.Update(productUpdate);
                var products = repository.GetAll().Where(p => p.Id == id).Include(pc => pc.ProductCategory).Include(pm => pm.Measurement).ToList();
                var productResponse = mapper.Map<ProductResponse>(products);
                return productResponse;
            }            
        }
    }
}
