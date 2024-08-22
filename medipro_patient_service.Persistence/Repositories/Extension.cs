using medipro_patient_service.Application.Interfaces.Repositories;
using medipro_patient_service.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;

namespace medipro_patient_service.Persistence.Repositories;

public static class Extension
{
    public static void AddRepositoriesAndServices(this IServiceCollection services)
    {
        services.AddScoped<AppDbContext>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
    }
}