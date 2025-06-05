using MarketApi.DTOs.ProductDTOs;
using MarketApi.Infrastructure.DataBase;
using MarketApi.Interfacies;
using MarketApi.Models;

namespace MarketApi.Repositories
{
    public class ProductRepository(ApplicationDbContext context) : Repository<Product>(context), IProductRepository
    {
    }
}
