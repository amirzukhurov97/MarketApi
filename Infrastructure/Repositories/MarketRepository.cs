using MarketApi.DTOs.Market;
using MarketApi.Infrastructure.DataBase;
using MarketApi.Infrastructure.Interfacies;
using MarketApi.Models;
using MarketApi.Repositories;

namespace MarketApi.Infrastructure.Repositories
{
    public class MarketRepository(ApplicationDbContext context) : Repository<Market>(context), IMarketRopository
    {
    }
}
