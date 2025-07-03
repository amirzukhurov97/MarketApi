using MarketApi.DTOs.EntityBase;
using MarketApi.Models.Abstract.Entity;

namespace MarketApi.DTOs.Address
{
    public record AddressResponse : EntityBaseResponse
    {
        public string Name { get; set; } = string.Empty;
    }
}
