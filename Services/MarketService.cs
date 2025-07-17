using AutoMapper;
using MarketApi.DTOs.Market;
using MarketApi.DTOs.Purchase;
using MarketApi.Infrastructure.Interfacies;
using MarketApi.Models;
using MarketApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MarketApi.Services
{
    public class MarketService(IMarketRopository repository, IMapper mapper)
    {

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
    }
}
