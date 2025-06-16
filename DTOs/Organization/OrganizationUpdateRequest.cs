using MarketApi.DTOs.EntityBase;

namespace MarketApi.DTOs.Organization
{
    public record OrganizationUpdateRequest : BaseProps
    {
        public string? PhoneNumber { get; set; }
        public Guid OrganizationTypeId { get; set; }
        public Guid AddressId { get; set; }
    }
}
