using AutoMapper;
using MarketApi.DTOs.ProductDTOs;
using MarketApi.Interfacies;
using MarketApi.Models;

namespace MarketApi.Services
{
    public class ProductServise(IProductRepository repository, IMapper mapper, IServiceProvider serviceProvider) : IProductServise
    {   
        public Product Add(ProductDTO product)
        {
            var productAdd = mapper.Map<Product>(product);
            repository.Add(productAdd);
            return productAdd;
        }

        public IEnumerable<Product> GetAll()
        {
            return repository.GetAll();
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
        public Product Update(Guid id, ProductDTO product)
        {
            var productUpdate = mapper.Map<Product>(product);
            var update = repository.Update(id, productUpdate);
            return update;
        }
    }
}
