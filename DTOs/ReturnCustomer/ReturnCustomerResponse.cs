using MarketApi.DTOs.EntityBase;

namespace MarketApi.DTOs.ReturnCustomer
{
    public record ReturnCustomerResponse : BaseProductResponse
    {
        public string CustomerName { get; set; } = string.Empty;
    }
}
