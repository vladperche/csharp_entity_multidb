
using Microsoft.Extensions.DependencyInjection;

namespace Entity.MultiDB.CrossCutting.Extensions;

public static class DatabaseExtension
{
    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<MultiDBContext>(options =>
            options.UseSqlServer(connectionString));
    }

    private static void AddPostgreSql(IServiceCollection services)
    {
        
    }
}
