using MarketApi.Infrastructure.DataBase;
using MarketApi.Infrastructure.Interfacies;
using MarketApi.Models;
using MarketApi.Repositories;

namespace MarketApi.Infrastructure.Repositories
{
    public class PurchaseRepository(ApplicationDbContext context) : Repository<Purchase>(context), IPurchaseRepository
    {
    }
}
