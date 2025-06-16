using MarketApi.DTOs.EntityBase;

namespace MarketApi.DTOs.ReturnOrganization
{
    public record ReturnOrganizationResponse : BaseProductResponse
    {
        public string OrganizationName { get; set; } = string.Empty;
    }
}
