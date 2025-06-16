using MarketApi.DTOs.EntityBase;
using MarketApi.Models;

namespace MarketApi.DTOs.OrganizationRequest
{
    public record OrganizationRequest : BaseProps
    {
        public string? PhoneNumber { get; set; }
        public Guid OrganizationTypeId { get; set; }
        public Guid AddressId { get; set; }
    }
}
