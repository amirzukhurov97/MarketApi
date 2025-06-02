using MarketApi.Interfacies;
using MarketApi.Models.Abstract;

namespace MarketApi.Repositories
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        private static List<T> _list = new List<T>();
        public T Add(T entity)
        {
            try
            {
                _list.Add(entity);
                return entity;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return _list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T GetById(Guid id)
        {
            return _list.Single(e=>e.Id==id);
        }

        public T Remove(Guid id)
        {
            var entity = GetById(id);
            if (entity != null) 
            {
                _list.Remove(entity);
                return entity;
            }
            return null;

        }

        public T Update(Guid id, T entity)
        {
            var entit = GetById(id);
            if (entit == null)
            {
                return null;
            }
            entit = entity;
            return entity;
        }
    }
}
