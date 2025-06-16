using MarketApi.DTOs.EntityBase;

namespace MarketApi.DTOs.ReturnCustomer
{
    public record ReturnCustomerRequest : BaseProductRequest
    {
        public Guid CustomerId { get; set; }
    }
}
