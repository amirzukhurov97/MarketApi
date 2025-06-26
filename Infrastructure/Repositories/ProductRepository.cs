using MarketApi.Infrastructure.DataBase;
using MarketApi.Infrastructure.Interfacies;
using MarketApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketApi.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override IQueryable<Product> GetAll()
        {
            return _context.Products.Include(pc=>pc.ProductCategory).Include(m=>m.Measurement);
        }
    }
}
