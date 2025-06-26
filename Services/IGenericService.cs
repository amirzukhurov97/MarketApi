using MarketApi.Models.Abstract.Entity;

namespace MarketApi.Services
{
    public interface IGenericService<TRequest, TUpdateRequest,TResponse> where TRequest: EntityBaseRequest where TUpdateRequest:EntityBaseUpdateRequest where TResponse : EntityBaseResponse
    {
        public string Create(TRequest item);
        IEnumerable<TResponse> GetAll();
        TResponse GetById(Guid id);
        string Update(TUpdateRequest item);
        string Remove(Guid id);
    }
}
