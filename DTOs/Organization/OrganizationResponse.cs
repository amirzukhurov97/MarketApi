﻿namespace MarketApi.DTOs.Organization
{
    public record OrganizationResponse
    {
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string OrganizationTypeName { get; set; } = string.Empty;
        public string AddressName { get; set; } = string.Empty;
    }
}
