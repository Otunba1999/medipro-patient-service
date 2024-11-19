using medipro_patient_service.Domain.Models;

namespace medipro_patient_service.Application.DTO;

public  class MedicalHistoryDto: BaseDto
{
    public PresentIllness? PresentIllness { get; init; }
    public ICollection<MedicationDto>? PastMedications { get; init; }
    public ICollection<MedicationDto>? CurrentMedications { get; init; }
    public ICollection<AllergyDto>? Allergies { get; init; }
    public ICollection<FamilyConditionDto>? FamilyConditions { get; init; }
    public ICollection<ImmunizationDto>? Immunizations { get; init; }
    public SubstanceUseDto? SubstanceUseDto { get; init; }
    public SexualHistoryDto? SexualHistory { get; set; }
    public string LivingSituation { get; init; } = string.Empty;
    public string SocialSupport { get; init; } = string.Empty;
    public ReviewOfSystemDto? ReviewOfSystem { get; init; }
    public string MentalHealthCondition { get; init; } = string.Empty;
    public ICollection<ScreeningDto>? Screenings { get; init; }
    public ICollection<VaccinationDto>? Vaccinations { get; init; }
    public Guid PatientId { get; init; }
}

public class UpdateMedicalHistory : BaseDto
{
    public string LivingSituation { get; init; } = string.Empty;
    public string SocialSupport { get; init; } = string.Empty;
    public string MentalHealthCondition { get; init; } = string.Empty;
}