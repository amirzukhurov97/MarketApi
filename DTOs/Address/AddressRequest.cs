using MarketApi.DTOs.EntityBase;
using MarketApi.Models.Abstract.Entity;

namespace MarketApi.DTOs.Address
{
    public record AddressRequest : EntityBaseRequest
    {
        public string Name { get; set; } = string.Empty;
    }
}
