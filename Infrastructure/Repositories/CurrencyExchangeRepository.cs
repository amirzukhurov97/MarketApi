using MarketApi.Infrastructure.DataBase;
using MarketApi.Infrastructure.Interfacies;
using MarketApi.Models;
using MarketApi.Repositories;

namespace MarketApi.Infrastructure.Repositories
{
    public class CurrencyExchangeRepository(ApplicationDbContext context) : Repository<CurrencyExchange>(context), ICurrencyExchangeRepository 
    {
    }
}
