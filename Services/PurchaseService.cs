using AutoMapper;
using k8s.KubeConfigModels;
using MarketApi.DTOs.Product;
using MarketApi.DTOs.Purchase;
using MarketApi.Infrastructure.Interfacies;
using MarketApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MarketApi.Services
{
    public class PurchaseService(IPurchaseRepository repository,IMarketRopository marketRopository, IMapper mapper) : IGenericService<PurchaseRequest, PurchaseUpdateRequest, PurchaseResponse>
    {
        public string Create(PurchaseRequest item)
        {
            if (item == null)
            {
                return "Purchase cannot be empty";
            }
            if(item?.ProductId == null)
            {
                return "ProductName cannot be empty";
            }
            if(item?.OrganizationId == null)
            {
                return "OrganizationName cannot be empty";
            }
            if(item?.Price == null)
            {
                return "Price cannot be empty";
            }
            if(item?.PriceUSD == null)
            {
                return "PriceUSD cannot be empty";
            }
            if(item?.Quantity == null)
            {
                return "Quantity cannot be empty";
            }
            else
            {
                var mapQuantity = mapper.Map<Purchase>(item);
                repository.Add(mapQuantity);
                var market = marketRopository.GetAll().FirstOrDefault(m => m.ProductId == item.ProductId);

                if (market != null)
                {
                    market.Quantity += item.Quantity;
                    marketRopository.Update(market);
                }
                else
                {
                    var newMarket = new Market
                    {
                        Id = Guid.NewGuid(),
                        ProductId = item.ProductId,
                        Quantity = item.Quantity
                    };
                    marketRopository.Add(newMarket);
                }
                return $"Created new item with this ID: {mapQuantity.Id}";
            }
        }

        public IEnumerable<PurchaseResponse> GetAll()
        {
            try
            {
                List<PurchaseResponse>? responses = new List<PurchaseResponse>();
                var purchases = repository.GetAll().Include(pc => pc.Product).Include(pm => pm.Organization).ToList();
                if (purchases.Count > 0)
                {
                    foreach (var purchase in purchases)
                    {
                        var response = mapper.Map<PurchaseResponse>(purchase);
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

        public PurchaseResponse GetById(Guid id)
        {
            try
            {
                PurchaseResponse responses = null;
                var purchaseList = repository.GetById(id).Include(pc => pc.Product).Include(pm => pm.Organization).ToList();
                if (purchaseList.Count > 0)
                {
                    responses = mapper.Map<PurchaseResponse>(purchaseList[0]);
                }
                return responses;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string Remove(Guid id)
        {
            var _item = repository.GetById(id).ToList();
            if (_item.Count()==0)
            {
                return "Purchase is not found";
            }
            repository.Remove(id);

            return "Purchase is deleted";
        }

        public string Update(PurchaseUpdateRequest item)
        {
            try
            {
                var _item = repository.GetById(item.Id).ToList();
                if (_item is null)
                {
                    return "Purchase is not found";
                }
                var mapPurchase = mapper.Map<Purchase>(item);
                repository.Update(mapPurchase);
                return "Purchase is updated";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
