
using Entity.MultiDB.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entity.MultiDB.Infrastructure.Contexts;

public abstract class ContextBase : DbContext 
{
    public ContextBase(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ProductModel> Products { get; set; } = null!;
}
