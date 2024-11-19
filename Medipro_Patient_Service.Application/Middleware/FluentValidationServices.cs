using FluentValidation;
using FluentValidation.AspNetCore;
using medipro_patient_service.Application.Validations;
using Microsoft.Extensions.DependencyInjection;

namespace medipro_patient_service.Application.Middleware;

public static class FluentValidationServices
{
    public static IServiceCollection AddFluentValidationService(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<AllergyValidator>();
        services.AddValidatorsFromAssemblyContaining<ChronicConditionValidator>();
        services.AddValidatorsFromAssemblyContaining<FamilyConditionValidator>();
        services.AddValidatorsFromAssemblyContaining<SubstanceUseValidator>();
        services.AddValidatorsFromAssemblyContaining<SexualHistoryValidator>();
        services.AddValidatorsFromAssemblyContaining<ScreeningValidator>();
        services.AddValidatorsFromAssemblyContaining<ImmunizationValidator>();
        services.AddValidatorsFromAssemblyContaining<MedicationValidator>();
        services.AddValidatorsFromAssemblyContaining<PresentIllnessValidator>();
        services.AddValidatorsFromAssemblyContaining<SurgeryValidator>();
        services.AddValidatorsFromAssemblyContaining<VaccinationValidator>();
        services.AddValidatorsFromAssemblyContaining<IllnessValidator>();
        services.AddValidatorsFromAssemblyContaining<InjuryValidator>();
        services.AddValidatorsFromAssemblyContaining<BasicInfoValidator>();
        return services;
    }
}