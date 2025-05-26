using MarketApi.Models.Abstract;

namespace MarketApi.Models
{
    public class Customer : EntityBase
    {
        public string Name { get; set; } 
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
