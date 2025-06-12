using MarketApi.DTOs.ProductDTOs;
using MarketApi.Models;

namespace MarketApi.Services
{
    public interface IProductServise
    {
        IEnumerable<ProductResponse> GetAll();
        IEnumerable<ProductResponse> GetById(Guid id);
        Product Add(DTOs.ProductDTOs.ProductRequest product);
        Product Remove(Guid id);
        ProductResponse Update(Guid id, ProductUpdateRequest product);
    }
}
