
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Entity.MultiDB.Infrastructure.Contexts;
using Entity.MultiDB.Entities.Resources;

namespace Entity.MultiDB.CrossCutting.Extensions;

public static class DatabaseExtension
{
    public static void AddDatabaseContext(this IServiceCollection services)
    {
        var databaseType = Environment.GetEnvironmentVariable("DATABASE_TYPE")?.ToLower();
        Console.WriteLine($"Database Type: {databaseType}");
        switch (databaseType)
        {
            case "postgresql":
                AddPostgreSql(services);
                break;
            case "sqlserver":
                AddSqlServer(services);
                break;
            case "mysql":
                AddMySql(services);
                break;
            default:
                throw new InvalidOperationException(string.Format(Messages.DATABASE_TYPE_UNSUPORTED, databaseType));
        }
    }

    private static void AddPostgreSql(IServiceCollection services)
    {
        var host = Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? throw new InvalidOperationException(Messages.POSTGRES_HOST_EMPTY);
        var port = Environment.GetEnvironmentVariable("POSTGRES_PORT") ?? "5432";
        Console.WriteLine($"PostgreSQL Host: {host}:{port}");
        
        var database = Environment.GetEnvironmentVariable("POSTGRES_DB") ?? throw new InvalidOperationException(Messages.POSTGRES_DB_EMPTY);
        var username = Environment.GetEnvironmentVariable("POSTGRES_USER") ?? throw new InvalidOperationException(Messages.POSTGRES_USERNAME_EMPTY);
        var password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? throw new InvalidOperationException(Messages.POSTGRES_PASSWORD_EMPTY);
        var connectionString = string.Format("server={0};Port={1};database={2};user id={3};password={4}", host, port, database, username, password);
        services.AddDbContext<ContextPostgreSQL>(options =>
            options.UseNpgsql(connectionString));
    }

    private static void AddSqlServer(IServiceCollection services)
    {
        
    }

    private static void AddMySql(IServiceCollection services)
    {
        
    }

    public static IServiceProvider MigrateDatabase(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var databaseType = Environment.GetEnvironmentVariable("DATABASE_TYPE")?.ToLower();
        switch (databaseType)
        {
            case "postgresql":
                var dbContext = scope.ServiceProvider.GetRequiredService<ContextPostgreSQL>();
                dbContext.Database.Migrate();
                break;
            default:
                throw new InvalidOperationException(string.Format(Messages.DATABASE_TYPE_UNSUPORTED, databaseType));
        }

        return serviceProvider;
    }
}
