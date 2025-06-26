using MarketApi.Infrastructure.DataBase;
using MarketApi.Infrastructure.Interfacies;
using MarketApi.Models.Abstract.Entity;
using Microsoft.EntityFrameworkCore;

namespace MarketApi.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : EntityBase
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public T Add(T item)
        {
            try
            {
                _dbSet.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual IQueryable<T> GetAll()
        {
            try
            {
                return _dbSet.AsQueryable();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<T> GetById(Guid id)
        {
            try
            {
                return _dbSet.AsQueryable();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Remove(Guid id)
        {
            try
            {
                var item = GetById(id).ToList();
                _dbSet.Remove(item[0]);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Update(T item)
        {
            try
            {
                var itemResult = GetById(item.Id);

                _context.Entry(itemResult).State = EntityState.Detached;
                item.Id = item.Id;
                _context.Entry(item).State = EntityState.Modified;
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
