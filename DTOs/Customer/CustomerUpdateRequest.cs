using MarketApi.DTOs.EntityBase;
using MarketApi.Models.Abstract.Entity;

namespace MarketApi.DTOs.Customer
{
    public record CustomerUpdateRequest : EntityBaseUpdateRequest
    {
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public Guid AddressId { get; set; }
    }
}
