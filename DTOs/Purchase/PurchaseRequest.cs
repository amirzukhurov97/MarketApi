using MarketApi.DTOs.EntityBase;

namespace MarketApi.DTOs.Purchase
{
    public record PurchaseRequest : BaseProductRequest
    {
        public Guid OrganizationId { get; set; }
    }
}
