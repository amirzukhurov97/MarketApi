﻿using MarketApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketApi.Infrastructure.EntityConfigurations
{
    public class ReturnOrganizationConfiguration : IEntityTypeConfiguration<ReturnOrganization>
    {
        public void Configure(EntityTypeBuilder<ReturnOrganization> builder)
        {
            builder.Property(p => p.Quantity)
                .IsRequired();
            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            builder.Property(p => p.PriceUSD)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            builder.Property(p => p.SumPrice)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            builder.Property(p => p.SumPriceUSD)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
        }
    }
}
