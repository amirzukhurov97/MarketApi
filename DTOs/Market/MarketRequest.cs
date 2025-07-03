using MarketApi.Models.Abstract.Entity;

namespace MarketApi.DTOs.Market
{
    public record MarketRequest : EntityBaseRequest
    {
        public double Quantity { get; set; }
        public Guid ProductId { get; set; }
    }
}
