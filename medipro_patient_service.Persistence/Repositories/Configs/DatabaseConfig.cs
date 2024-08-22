using medipro_patient_service.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace medipro_patient_service.Persistence.Repositories.Configs;

public static class DatabaseConfig
{
    public static void AddDatabaseService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("MediproConnection")).UseNpgsql());
    }
}