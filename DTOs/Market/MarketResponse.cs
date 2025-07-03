using MarketApi.Models.Abstract.Entity;

namespace MarketApi.DTOs.Market
{
    public record MarketResponse : EntityBaseResponse
    {
        public double Quantity { get; set; }
        public string? ProductName { get; set; }
    }
}
