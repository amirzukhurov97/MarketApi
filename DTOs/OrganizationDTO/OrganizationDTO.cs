﻿namespace MarketApi.DTOs.OrganizationDTO
{
    public record OrganizationDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}
