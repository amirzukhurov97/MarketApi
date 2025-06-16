using MarketApi.DTOs.EntityBase;

namespace MarketApi.DTOs.Customer
{
    public record CustomerRequest: BaseProps
    {
        public string PhoneNumber { get; set; } = string.Empty;
        public Guid AddressId { get; set; }
    }
}
