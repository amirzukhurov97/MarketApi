using AutoMapper;
using Azure;
using MarketApi.DTOs.Product;
using MarketApi.Infrastructure.Interfacies;
using MarketApi.Models;
using MarketApi.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace MarketApi.Services
{
    public class ProductServise(IProductRepository repository, IMapper mapper) : IGenericService<ProductRequest, ProductUpdateRequest, ProductResponse>
    {
        //public Product Add(ProductRequest product)
        //{
        //    try
        //    {
        //        var productExists = repository.GetAll().Any(p => p.Name == product.Name && p.Capacity == product.Capacity && p.MeasurementId == product.MeasurementId && p.ProductCategoryId == product.ProductCategoryId);
        //        if (productExists)
        //        {
        //            throw new Exception("Product already exists with the same name, capacity, measurement, and category.");
        //        }
        //        var productAdd = mapper.Map<Product>(product);
        //        repository.Add(productAdd);
        //        return productAdd;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }            
        //}
        //public IEnumerable<productResponse> GetAll()
        //{
        //    List<productResponse>? responses = new List<productResponse>();
        //    var products = repository.GetAll().Include(pc=>pc.ProductCategory).Include(pm=>pm.Measurement).ToList();
        //    if (products.Count > 0) {
        //        foreach (var product in products)
        //        {
        //            var response = mapper.Map<productResponse>(product);
        //            responses.Add(response);
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception("No products found.");
        //    }
        //    return responses;
        //}

        //public IEnumerable<productResponse> GetById(Guid id)
        //{
        //    List<productResponse>? response = new List<productResponse>();
        //    var products = repository.GetAll().Where(p=>p.Id==id).Include(pc => pc.ProductCategory).Include(pm => pm.Measurement).ToList();
        //    if (products == null)
        //    {
        //        throw new Exception($"Product with id {id} not found.");
        //    }
        //    foreach (var product in products)
        //    {
        //        var productResponse = mapper.Map<productResponse>(product);
        //        response.Add(productResponse);
        //    }

        //    return response;
        //}

        //public Product Remove(Guid id)
        //{
        //    throw new NotImplementedException();
        //    //var resDelete =  repository.Remove(id);
        //    //if (resDelete == null)
        //    //{
        //    //    throw new Exception($"Product with id {id} not found.");
        //    //}
        //    //return resDelete;
        //}
        //public IEnumerable<productResponse> Update(Guid id, ProductUpdateRequest product)
        //{
        //    if (product == null)
        //    {
        //        throw new ArgumentNullException(nameof(product), "ProductUpdateRequest cannot be null");
        //    }
        //    var existingProduct = repository.GetById(id);
        //    if (existingProduct == null) 
        //    {
        //        throw new Exception($"Product with id {id} not found.");
        //    }
        //    else
        //    {
        //        var productUpdate = mapper.Map<Product>(product);
        //        var update = repository.Update(productUpdate);
        //        var productResponse = GetById(id);
        //        return productResponse;
        //    }            
        //}
        public string Create(ProductRequest item)
        {
            if (string.IsNullOrEmpty(item.Name))
            {
                return "The name cannot be empty";
            }
            else
            {
                var mapProduct = mapper.Map<Product>(item);
                repository.Add(mapProduct);
                return $"Created new item with this ID: {mapProduct.Id}";
            }
        }

        public IEnumerable<ProductResponse> GetAll()
        {
            try
            {
                List<ProductResponse>? responses = new List<ProductResponse>();
                var products = repository.GetAll().Include(pc => pc.ProductCategory).Include(pm => pm.Measurement).ToList();
                if (products.Count > 0)
                {
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
            catch (Exception)
            {
                throw;
            }
        }

        public ProductResponse GetById(Guid id)
        {
            try
            {
                ProductResponse responses = null;
                var productResponse = repository.GetById(id).Where(p=>p.Id==id).Include(pc => pc.ProductCategory).Include(pm => pm.Measurement).ToList();
                if (productResponse.Count >0)
                {
                    responses = mapper.Map<ProductResponse>(productResponse[0]);
                }                
                else
                {
                    throw new Exception($"No product found by id {id}.");
                }
                return responses;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Remove(Guid id)
        {
            var _item = repository.GetById(id);
            if (_item is null)
            {
                return "Doctor is not found";
            }
            repository.Remove(id);

            return "Product is deleted";
        }

        public string Update(ProductUpdateRequest item)
        {
            try
            {
                var _item = repository.GetById(item.Id).ToList();
                if (_item is null)
                {
                    return "Doctor is not found";
                }
                var mapProduct = mapper.Map<Product>(item);
                mapProduct.Id = _item[0].Id;
                repository.Update(mapProduct);
                return "Doctor is updated";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
