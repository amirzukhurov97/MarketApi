using MarketApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketApi.Infrastructure.EntityConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p => p.ProductCategory)
                .WithMany(pc => pc.Products)                
                .HasForeignKey(p => p.ProductCategoryId)                
                .OnDelete(DeleteBehavior.Restrict);   


        }
    }
}
