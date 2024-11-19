using medipro_patient_service.Application.Exceptions;
using medipro_patient_service.Application.Helper;
using Medipro_Patient_Service.Application.Interfaces.Helper;
using medipro_patient_service.Application.Interfaces.HttpService;
using medipro_patient_service.Application.Interfaces.Redis;
using medipro_patient_service.Application.Interfaces.Repositories;
using medipro_patient_service.Application.Interfaces.Sevices;
using medipro_patient_service.Application.Profiles;
using medipro_patient_service.Application.Redis;
using medipro_patient_service.Application.Services;
using Medipro_Patient_Service.Common.Requests;
using medipro_patient_service.Domain.Models;
using Medipro_Patient_Service.Infrastructure.HttpService;
using medipro_patient_service.Persistence.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace medipro_patient_service.Persistence.Repositories;

public static class Extension
{
    /// <summary>
    /// Register services and inject them in the app context
    /// </summary>
    /// <param name="services">receives  Microsoft IServiceCollection</param>
    public static void AddRepositoriesAndServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<AppDbContext>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IPatientService, PatientService>();

        services.AddScoped<IGenericService<Contact>, ContactService>();
        services.AddScoped<IGenericService<PresentIllness>, PresentIllnessService>();
        services.AddScoped<IGenericService<Medication>, MedicationService>();
        services.AddScoped<IGenericService<Allergy>, AllergyService>();
        services.AddScoped<IGenericService<FamilyCondition>, FamilyConditionService>();
        services.AddScoped<IGenericService<Immunization>, ImmunizationService>();
        services.AddScoped<IGenericService<SexualHistory>, SexualHistoryService>();
        services.AddScoped<IGenericService<SubstanceUse>, SubstanceUseService>();
        services.AddScoped<IGenericService<ReviewOfSystem>, ReviewOfSystemService>();
        services.AddScoped<IGenericService<Screening>, ScreeningService>();
        services.AddScoped<IGenericService<Vaccination>, VaccinationService>();
        services.AddScoped<IGenericService<PastMedicalHistory>, PastMedicalHistoryService>();
        services.AddScoped<IGenericService<MedicalHistory>, MedicalHistoryService>();
        services.AddScoped<IGenericService<ChronicCondition>, ChronicConditionService>();
        services.AddScoped<IGenericService<Illness>, IllnessService>();
        services.AddScoped<IGenericService<Injury>, InjuryService>();
        services.AddScoped<IGenericService<Surgery>, SurgeryService>();

        services.AddExceptionHandler<OperationException>();

        AddHttpClient(services, config);

        services.AddScoped(typeof(IHttpService<MailRequest>), typeof(EmailService));
        services.AddScoped<IHttpService<AppointmentRequest>, AppointmentService>();
        
        services.AddScoped<IRedisCachedService, RedisCachedService>();
        services.AddScoped<IUserDetailsHelper, UserDetailsHelper>();

        services.AddAutoMapper(typeof(MappingProfile));
        // services.AddSingleton<RestClient>();
    }

    private static void AddHttpClient(IServiceCollection services, IConfiguration config)
    {
        var appointmentName = config["HttpClientName:AppointmentClient"];
        ArgumentException.ThrowIfNullOrEmpty(appointmentName);
        services.AddHttpClient(
            appointmentName,
            client =>
            {
                client.BaseAddress = new Uri("http://localhost:8383/api/medipro-appointment/");
                
            });
        var emailName = config["HttpClientName:EmailClient"];
        ArgumentException.ThrowIfNullOrEmpty(emailName);
        services.AddHttpClient(
            emailName,
            client =>
            {
                client.BaseAddress = new Uri("http://localhost:8282/api/medipro/");
                
            });
    }
}