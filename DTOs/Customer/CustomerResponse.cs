using MarketApi.DTOs.EntityBase;
using MarketApi.Models.Abstract.Entity;

namespace MarketApi.DTOs.Customer
{
    public record CustomerResponse :EntityBaseResponse
    {
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string AddressName { get; set; } = string.Empty;
    }
}
