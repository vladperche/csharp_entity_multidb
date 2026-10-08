
using Entity.MultiDB.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.MultiDB.Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<ProductModel>
{
    public void Configure(EntityTypeBuilder<ProductModel> builder)
    {
        builder.HasKey(p => p.ProductId);
        builder.Property(p => p.ProductId).IsRequired().ValueGeneratedOnAdd();
        builder.Property(p => p.ProductCode).IsRequired().HasMaxLength(20);
        builder.Property(p => p.ProductName).IsRequired().HasMaxLength(100);
        builder.Property(p => p.BaseUnit).IsRequired().HasMaxLength(50);
    }
}
