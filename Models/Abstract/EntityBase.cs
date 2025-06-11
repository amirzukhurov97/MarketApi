namespace MarketApi.Models.Abstract
{
    public abstract class EntityBase
    {        
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
