using MarketApi.Models;

namespace MarketApi.DTOs.OrganizationRequest
{
    public record OrganizationRequest
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public Guid OrganizationTypeId { get; set; }
        public Guid AddressId { get; set; }
    }
}
