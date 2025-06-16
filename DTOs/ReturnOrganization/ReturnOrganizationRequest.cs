using MarketApi.DTOs.EntityBase;

namespace MarketApi.DTOs.ReturnOrganization
{
    public record ReturnOrganizationRequest : BaseProductRequest
    {
        public Guid OrganizationId { get; set; }
    }
}
