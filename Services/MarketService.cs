using AutoMapper;
using MarketApi.DTOs.Market;
using MarketApi.DTOs.Purchase;
using MarketApi.Infrastructure.Interfacies;
using MarketApi.Models;
using MarketApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MarketApi.Services
{
    public class MarketService(IMarketRopository repository, IMapper mapper) : IGenericService<MarketRequest, MarketUpdateRequest, MarketResponse>
    {
        public string Create(MarketRequest item)
        {
            if (item?.ProductId == null)
            {
                return "ProductName cannot be empty";
            }
            else
            {
                var mapMarket = mapper.Map<Market>(item);
                repository.Add(mapMarket);
                return $"Created new item with this ID: {mapMarket.Id}";
            }
        }

        public IEnumerable<MarketResponse> GetAll()
        {
            try
            {
                List<MarketResponse>? responses = new List<MarketResponse>();
                var products = repository.GetAll().Include(pc => pc.Product).ToList();
                if (products.Count > 0)
                {
                    foreach (var puroduct in products)
                    {
                        var response = mapper.Map<MarketResponse>(puroduct);
                        responses.Add(response);
                    }
                }
                return responses;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public MarketResponse GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public string Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public string Update(MarketUpdateRequest item)
        {
            try
            {
                var _item = repository.GetById(item.Id).ToList();
                if (_item is null)
                {
                    return "Product is not found";
                }
                var mapMarket = mapper.Map<Market>(item);
                repository.Update(mapMarket);
                return "Market is updated";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
