using MarketApi.Models.Abstract;

namespace MarketApi.Models
{
    public class ReturnOrganization : EntityBase
    {
        public decimal Price { get; set; }
        public decimal PriceUSD { get; set; }
        public double Quantity { get; set; }
        public decimal SumPrice { get; set; }
        public decimal SumPriceUSD { get; set; }
        public DateTime Date { get; set; }
        public string? Comment { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrganizationId { get; set; }
        public Organization Organization { get; set; } = null!;
        public Product Product { get; set; } = null!;
    }
}
