using MarketApi.Models.Abstract;

namespace MarketApi.Models
{
    public class Purchase : EntityBase
    {
        public Guid ProductId { get; set; }
        public Guid OrganizationId { get; set; }

    }
}
