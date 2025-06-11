namespace MarketApi.DTOs.Customer
{
    public record CustomerResponse
    {
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string AddressName { get; set; } = string.Empty;
    }
}
