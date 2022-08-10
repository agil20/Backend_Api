using ApiAplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ApiAplication.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired(true).HasMaxLength(10);

            builder.Property(p => p.Price).IsRequired(true).HasDefaultValue(10);
          builder.Property(p => p.IsDeleted).HasDefaultValue(false);
            //  builder.Property(p => p.CreateTime).HasDefaultValue(DateTime.UtcNow);

            builder.Property(p => p.CreateTime).HasDefaultValueSql("GETUTCDATE()");


        }
    }
}
