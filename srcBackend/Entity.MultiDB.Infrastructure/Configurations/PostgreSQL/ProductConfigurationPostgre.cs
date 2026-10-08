
using Entity.MultiDB.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.MultiDB.Infrastructure.Configurations.PostgreSQL;

public class ProductConfigurationPostgre : ProductConfiguration
{
    public new void Configure(EntityTypeBuilder<ProductModel> builder)
    {
        base.Configure(builder);

        builder.ToTable("Products", "public");
        builder.Property(p => p.ProductId).HasColumnType("uuid");
    }
}