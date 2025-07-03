using MarketApi.Infrastructure.DataBase;
using MarketApi.Infrastructure.Interfacies;
using MarketApi.Models;
using MarketApi.Repositories;

namespace MarketApi.Infrastructure.Repositories
{
    public class AddressRepository(ApplicationDbContext context) : Repository<Address>(context), IAddressRepository
    {
    }
}
