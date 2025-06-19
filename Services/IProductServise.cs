using MarketApi.DTOs.Product;
using MarketApi.Models;

namespace MarketApi.Services
{
    public interface IProductServise
    {
        IEnumerable<ProductResponse> GetAll();
        IEnumerable<ProductResponse> GetById(Guid id);
        Product Add(ProductRequest product);
        Product Remove(Guid id);
        IEnumerable<ProductResponse> Update(Guid guid,ProductUpdateRequest product);
    }
}
