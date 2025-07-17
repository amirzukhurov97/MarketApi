using MarketApi.DTOs.Market;
using MarketApi.Infrastructure.DataBase;
using MarketApi.Infrastructure.Interfacies;
using MarketApi.Models;
using MarketApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MarketApi.Infrastructure.Repositories
{
    public class MarketRepository(ApplicationDbContext context) :  IMarketRopository
    {
        public string Expense(Market item)
        {
            try
            {
                var market = context.Markets.FirstOrDefault(m => m.ProductId == item.ProductId);

                if (market != null)
                {
                    market.Quantity -= item.Quantity;
                    context.Update(market);
                    //context.SaveChanges();
                    return $"Updated market for product ID: {item.ProductId} with new quantity: {market.Quantity}";
                }
                else
                {
                    var newMarket = new Market
                    {
                        Id = Guid.NewGuid(),
                        ProductId = item.ProductId,
                        Quantity = item.Quantity
                    };
                    context.Add(newMarket);
                    //context.SaveChanges();
                    return $"Created new market entry for product ID: {item.ProductId} with quantity: {newMarket.Quantity}";
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public IQueryable<Market> GetAll()
        {
            try
            {
                return context.Markets.AsQueryable();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string Income(Market item)
        {
            try
            {
                var market = context.Markets.FirstOrDefault(m => m.ProductId == item.ProductId);

                if (market != null)
                {
                    market.Quantity += item.Quantity;
                    context.Update(market);
                    //context.SaveChanges();
                    return $"Updated market for product ID: {item.ProductId} with new quantity: {market.Quantity}";
                }
                else
                {
                    var newMarket = new Market
                    {
                        Id = Guid.NewGuid(),
                        ProductId = item.ProductId,
                        Quantity = item.Quantity
                    };
                    context.Add(newMarket);
                    //context.SaveChanges();
                    return $"Created new market entry for product ID: {item.ProductId} with quantity: {newMarket.Quantity}";
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
