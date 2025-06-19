using MarketApi.Infrastructure.DataBase;
using MarketApi.Infrastructure.Interfacies;
using MarketApi.Models;

namespace MarketApi.Repositories
{
    public class OrganizationRepository(ApplicationDbContext context) : Repository<Organization>(context), IOrganizationRepository
    {
    }
}
