using MarketApi.Models.Abstract;

namespace MarketApi.Models
{
    public class Organization : EntityBase
    {
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public OrganizationType OrganizationType { get; set; } = null!;
        public Guid OrganizationTypeId { get; set; }
        public Guid AddressId { get; set; }
        public Address? Address { get; set; } = null!;
        public List<Purchase> Purchases { get; set; } = new List<Purchase>();
        public List<ReturnOrganization> ReturnOrganizations { get; set; } = new List<ReturnOrganization>();
    }
}
