namespace MarketApi.DTOs.ProductDTOs
{
    public class ProductResponse
    {
        public string Name { get; set; } = string.Empty;
        public double Capacity { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? MeasurementName { get; set; }
        public string? ProductCategoryName { get; set; }
    }
}
