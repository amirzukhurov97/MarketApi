using MarketApi.Models.Abstract.Entity;

namespace MarketApi.DTOs.Address
{
    public record AddressUpdateRequest: EntityBaseUpdateRequest
    {
        public string Name { get; set; } = string.Empty;

    }
}
