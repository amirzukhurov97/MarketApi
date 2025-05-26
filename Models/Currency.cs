using MarketApi.Models.Abstract;

namespace MarketApi.Models
{
    public class Currency : EntityBase
    {
        public decimal USDtoTJS { get; set; }
        public DateTime DateTime {  get; set; }
    }
}
