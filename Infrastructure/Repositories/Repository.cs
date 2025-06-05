using MarketApi.Infrastructure.DataBase;
using MarketApi.Interfacies;
using MarketApi.Models.Abstract;
using Microsoft.EntityFrameworkCore;

namespace MarketApi.Repositories
{
    public class Repository<T>(ApplicationDbContext context) : IRepository<T> where T : EntityBase
    {
        public T Add(T entity)
        {
            try
            {
                context.Add(entity);
                context.SaveChanges();  
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                return context.Set<T>().AsQueryable();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T GetById(Guid id)
        {
            try
            {
                return context.Find<T>(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public T Remove(Guid id)
        {
            var entity = GetById(id);
            if (entity != null) 
            {
                context.Remove(entity);
                context.SaveChanges();
                return entity;
            }
            return null;

        }

        public T Update(Guid id, T entity)
        {
            context.Update(entity);
            context.SaveChanges();
            return entity;
        }
    }
}
