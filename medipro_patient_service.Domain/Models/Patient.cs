using medipro_patient_service.Domain.Enums;

namespace medipro_patient_service.Domain.Models;

public class Patient : Entity
{
    public string FirstName { get; init; } = string.Empty;
    public string LasttName { get; init; } = string.Empty;
    public DateOnly DateOfBirth { get; init; }
    public Gender Gender { get; init; }
    public Contact? Contact { get; init; }
    public string Occupation { get; init; } = string.Empty;
    public string LifeStyle { get; init; } = string.Empty;
    public MedicalHistory? MedicalHistory { get; init; }
    public PastMedicalHistory? PastMedicalHistory { get; init; }
    public ICollection<Medication>? CurrentMedications { get; init; }
    public HealthCareProvider? HealthCareProvider { get; init; }
    public Guid HealthCareProviderId { get; init; }
}