using MarketApi.Infrastructure.DataBase;
using MarketApi.Interfacies;
using MarketApi.Models;

namespace MarketApi.Repositories
{
    public class CustomerRepository(ApplicationDbContext context) : Repository<Customer>(context), ICustomerRepository
    {
       
    }
}
