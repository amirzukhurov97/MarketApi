using MarketApi.DTOs.EntityBase;

namespace MarketApi.DTOs.Customer
{
    public record CustomerResponse :BaseProps
    {
        public string PhoneNumber { get; set; } = string.Empty;
        public string AddressName { get; set; } = string.Empty;
    }
}
