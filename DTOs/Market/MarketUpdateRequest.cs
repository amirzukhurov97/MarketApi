using MarketApi.Models.Abstract.Entity;

namespace MarketApi.DTOs.Market
{
    public record MarketUpdateRequest : EntityBaseUpdateRequest
    {
        public double Quantity { get; set; }
        public Guid ProductId { get; set; }
    }
}
