using MarketApi.Infrastructure.DataBase;
using MarketApi.Infrastructure.Interfacies;
using MarketApi.Models;
using MarketApi.Repositories;

namespace MarketApi.Infrastructure.Repositories
{
    public class MeasurementRepository(ApplicationDbContext context) : Repository<Measurement>(context), IMeasurementRepository
    {
    }
}
