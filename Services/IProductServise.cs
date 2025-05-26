using MarketApi.DTOs.ProductDTOs;
using MarketApi.Models;

namespace MarketApi.Services
{
    public interface IProductServise
    {
        IEnumerable<Product> GetAll();
        Product GetById(Guid id);
        Product Add(ProductDTO product);
        Product Remove(Guid id);
        Product Update(Guid id, ProductDTO product);
    }
}
