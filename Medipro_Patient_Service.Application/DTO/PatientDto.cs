using medipro_patient_service.Domain.Models;

namespace medipro_patient_service.Application.DTO;

public class PatientDto : BaseDto
{
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public DateOnly DateOfBirth { get; init; }
    public string Gender { get; init; } = string.Empty;
    public ContactDto? Contact { get; init; }
    public string Occupation { get; init; } = string.Empty;
    public string LifeStyle { get; init; } = string.Empty;
    
    public MedicalHistoryDto? MedicalHistory { get; init; }
    public PastMedicalHistoryDto? PastMedicalHistory { get; init; }
    public ICollection<MedicationDto>? CurrentMedications { get; init; }
    // public HealthCareProvider? HealthCareProvider { get; init; }
    // public Guid HealthCareProviderId { get; init; }
    public string UserId { get; init; } = string.Empty;
}