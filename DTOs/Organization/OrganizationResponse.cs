using MarketApi.DTOs.EntityBase;

namespace MarketApi.DTOs.Organization
{
    public record OrganizationResponse : BaseProps
    {
        public string PhoneNumber { get; set; } = string.Empty;
        public string OrganizationTypeName { get; set; } = string.Empty;
        public string AddressName { get; set; } = string.Empty;
    }
}
