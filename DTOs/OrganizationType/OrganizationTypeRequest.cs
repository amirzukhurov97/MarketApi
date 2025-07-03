using MarketApi.DTOs.EntityBase;
using MarketApi.Models.Abstract.Entity;

namespace MarketApi.DTOs.OrganizationType
{
    public record OrganizationTypeRequest : EntityBaseRequest
    {
        public string Name { get; set; } = string.Empty;
    }
}
