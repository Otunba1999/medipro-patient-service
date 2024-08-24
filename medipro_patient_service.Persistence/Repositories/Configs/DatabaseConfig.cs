using medipro_patient_service.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace medipro_patient_service.Persistence.Repositories.Configs;

public static class DatabaseConfig
{
    /// <summary>
    /// Register database service in the app context
    /// </summary>
    /// <param name="services">receives  Microsoft IServiceCollection</param>
    /// <param name="configuration">receives  Microsoft IConfiguration</param>
    public static void AddDatabaseService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("MediproConnection"));
        });
    }
}