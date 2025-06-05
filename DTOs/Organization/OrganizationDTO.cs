using MarketApi.Models;

namespace MarketApi.DTOs.OrganizationDTO
{
    public record OrganizationDTO
    {
        public string? Name { get; set; }
        public Address? Address { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
