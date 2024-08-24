using medipro_patient_service.Application.Interfaces.HttpService;
using medipro_patient_service.Application.Interfaces.Repositories;
using medipro_patient_service.Application.Interfaces.Sevices;
using medipro_patient_service.Application.Profiles;
using medipro_patient_service.Application.Services;
using medipro_patient_service.Domain.Models;
using medipro_patient_service.Infrastructure.HttpService;
using medipro_patient_service.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;

namespace medipro_patient_service.Persistence.Repositories;

public static class Extension
{
    /// <summary>
    /// Register services and inject them in the app context
    /// </summary>
    /// <param name="services">receives  Microsoft IServiceCollection</param>
    public static void AddRepositoriesAndServices(this IServiceCollection services)
    {
        // services.AddScoped<AppDbContext>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IPatientService, PatientService>();

        services.AddScoped<IGenericService<Contact>, ContactService>();
        
        services.AddScoped(typeof(IExternalApiService<>), typeof(ExternalApiService<>));

        services.AddAutoMapper(typeof(MappingProfile));
        
    }
}