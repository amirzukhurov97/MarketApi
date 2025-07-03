using MarketApi.DTOs.EntityBase;
using MarketApi.Models.Abstract.Entity;

namespace MarketApi.DTOs.OrganizationType
{
    public record OrganizationTypeUpdateRequest : EntityBaseUpdateRequest
    {
        public string Name { get; set; } = string.Empty;
    }
}
