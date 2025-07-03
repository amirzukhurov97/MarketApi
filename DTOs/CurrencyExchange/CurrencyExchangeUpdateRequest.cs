using MarketApi.Models.Abstract.Entity;

namespace MarketApi.DTOs.CurrencyExchange
{
    public record CurrencyExchangeUpdateRequest : EntityBaseUpdateRequest
    {
        public DateTime DateTime { get; set; }
        public decimal USDtoTJS { get; set; }
    }
}
