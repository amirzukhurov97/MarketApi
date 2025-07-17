using MarketApi.DTOs.Market;
using MarketApi.Models;

namespace MarketApi.Infrastructure.Interfacies
{
    public interface IMarketRopository
    {
        IQueryable<Market> GetAll();
        string Income(Market item);
        string Expense(Market item);
    }
}
