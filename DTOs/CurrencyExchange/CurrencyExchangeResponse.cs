using MarketApi.Models.Abstract.Entity;

namespace MarketApi.DTOs.CurrencyExchange
{
    public record CurrencyExchangeResponse : EntityBaseResponse
    {
        public DateTime DateTime { get; set; }

        public decimal USDtoTJS { get; set; }
    }
}
