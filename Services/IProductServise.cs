using MarketApi.DTOs.ProductDTOs;
using MarketApi.Models;

namespace MarketApi.Services
{
    public interface IProductServise
    {
        IEnumerable<ProductResponse> GetAll();
        Product GetById(Guid id);
        Product Add(DTOs.ProductDTOs.ProductRequest product);
        Product Remove(Guid id);
        Product Update(Guid id, ProductUpdateRequest product);
    }
}
