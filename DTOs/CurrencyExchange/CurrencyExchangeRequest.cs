using MarketApi.Models.Abstract.Entity;

namespace MarketApi.DTOs.CurrencyExchange
{
    public record CurrencyExchangeRequest : EntityBaseRequest
    {
        public DateTime DateTime { get; set; }
        public decimal USDtoTJS { get; set; }
    }
}
