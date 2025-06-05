using MarketApi.Models;
using MarketApi.Models.Abstract;

namespace MarketApi.Interfacies
{
    public interface IRepository<T> where T : class
    {        
        IQueryable<T> GetAll();
        T GetById(Guid id);
        T Add(T entity);
        T Remove(Guid id);
        T Update(Guid id, T entity);
    }
}