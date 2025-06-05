using MarketApi.Infrastructure.DataBase;
using MarketApi.Interfacies;
using MarketApi.Models;

namespace MarketApi.Repositories
{
    public class OrganizationRepository(ApplicationDbContext context) : Repository<Organization>(context), IOrganizationRepository
    {
    }
}
