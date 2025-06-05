namespace MarketApi.DTOs.ProductDTOs
{
    public record ProductUpdateRequest
    {
        public string Name { get; set; } = string.Empty;
        public double Capacity { get; set; }
        public string Description { get; set; } = string.Empty;
    }

}
