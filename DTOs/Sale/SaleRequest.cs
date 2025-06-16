using MarketApi.DTOs.EntityBase;

namespace MarketApi.DTOs.Sale
{
    public record SaleRequest : BaseProductRequest
    {
        public Guid CustomerId { get; set; }
    }
}
