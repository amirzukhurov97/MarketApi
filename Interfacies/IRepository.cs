using MarketApi.Models;

namespace MarketApi.Interfacies
{
    public interface IRepository<T> where T : class
    {        
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        T Add(T entity);
        T Remove(Guid id);
        T Update(Guid id, T entity);
    }
}