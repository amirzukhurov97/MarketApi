using MarketApi.DTOs.EntityBase;

namespace MarketApi.DTOs.Purchase
{
    public record PurchaseResponse : BaseProductResponse
    {
        public string OrganizationName { get; set; } = string.Empty;
    }
}
