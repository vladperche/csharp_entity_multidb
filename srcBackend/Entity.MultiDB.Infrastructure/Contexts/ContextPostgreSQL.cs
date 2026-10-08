
using Entity.MultiDB.Infrastructure.Configurations.PostgreSQL;
using Microsoft.EntityFrameworkCore;

namespace Entity.MultiDB.Infrastructure.Contexts;

public class ContextPostgreSQL : ContextBase
{
    public ContextPostgreSQL(DbContextOptions<ContextPostgreSQL> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductConfigurationPostgre());
        base.OnModelCreating(modelBuilder);
    }
}
