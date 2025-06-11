namespace MarketApi.DTOs.Organization
{
    public record OrganizationUpdateRequest
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public Guid OrganizationTypeId { get; set; }
        public Guid AddressId { get; set; }
    }
}
