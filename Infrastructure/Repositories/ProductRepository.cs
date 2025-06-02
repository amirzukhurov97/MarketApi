using MarketApi.DTOs.ProductDTOs;
using MarketApi.Interfacies;
using MarketApi.Models;

namespace MarketApi.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
    }
}
