using MarketApi.Models.Abstract.Entity;

namespace MarketApi.Models
{
    public class Market : EntityBase
    {
        public double Quantity { get; set; }
        public Guid ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
