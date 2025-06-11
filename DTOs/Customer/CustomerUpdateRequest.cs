namespace MarketApi.DTOs.Customer
{
    public record CustomerUpdateRequest
    {
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public Guid AddressId { get; set; }
    }
}
