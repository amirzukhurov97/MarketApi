using MarketApi.Infrastructure.DataBase;
using MarketApi.Infrastructure.Interfacies;
using MarketApi.Models;
using MarketApi.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MarketApi.Infrastructure.Repositories
{
    public class CurrencyExchangeRepository(ApplicationDbContext context) : Repository<CurrencyExchange>(context), ICurrencyExchangeRepository
    {
        public decimal GetActual()
        {
            CurrencyExchange? exchangeRate = _context.CurrencyExchange.LastOrDefault();
            if(exchangeRate == null)
            {
                return 0;
            }
            return exchangeRate.USDtoTJS;
        }
    }
}
