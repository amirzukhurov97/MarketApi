using MarketApi.DTOs.EntityBase;

namespace MarketApi.DTOs.Sale
{
    public record SaleResponse : BaseProductResponse
    {
        public string CustomerName { get; set; } = string.Empty;
    }
}
