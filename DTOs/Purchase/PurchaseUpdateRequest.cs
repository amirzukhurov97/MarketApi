using MarketApi.DTOs.EntityBase;
using MarketApi.Models.Abstract.Entity;

namespace MarketApi.DTOs.Purchase
{
    public record PurchaseUpdateRequest : EntityBaseUpdateRequest
    {
        public decimal Price { get; set; }
        public decimal PriceUSD { get; set; }
        public double Quantity { get; set; }
        public decimal SumPrice { get; set; }
        public decimal SumPriceUSD { get; set; }
        public DateTime Date { get; set; }
        public string? Comment { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrganizationId { get; set; }
    }
}
