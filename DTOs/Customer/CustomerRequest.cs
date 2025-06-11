using MarketApi.Models;

namespace MarketApi.DTOs.CustomerDTO
{
    public record CustomerRequest
    {
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public Guid AddressId { get; set; }
    }
}
