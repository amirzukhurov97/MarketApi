using MarketApi.Models.Abstract.Entity;

namespace MarketApi.Models
{
    public class CurrencyExchange : EntityBase
    {
        public decimal USDtoTJS { get; set; }
        public DateTime DateTime {  get; set; }
    }
}
