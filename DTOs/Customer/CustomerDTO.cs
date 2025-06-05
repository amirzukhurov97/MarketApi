using MarketApi.Models;

namespace MarketApi.DTOs.CustomerDTO
{
    public record CustomerDTO
    {
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public Address? AddressName { get; set; }
    }
}
