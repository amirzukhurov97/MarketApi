using MarketApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketApi.Infrastructure.EntityConfigurations
{
    public class MarketConfiguration : IEntityTypeConfiguration<Market>
    {
        public void Configure(EntityTypeBuilder<Market> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasOne(m => m.Product);
        }
    }
}
