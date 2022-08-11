using ApiAplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiAplication.Configuration
{
    public class CategoryConfiguration
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.Name).IsRequired(true).HasMaxLength(10);

           
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);
        

            builder.Property(p => p.CreateTime).HasDefaultValueSql("GETUTCDATE()");


        }
    }
}
