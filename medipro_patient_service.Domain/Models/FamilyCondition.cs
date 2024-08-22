namespace medipro_patient_service.Domain.Models;

public class FamilyCondition : Entity
{
    public string Condition { get; init; } = string.Empty;
    public string Relative { get; init; } = string.Empty;
    public MedicalHistory? MedicalHistory { get; init; }
    public Guid MedicalHistoryId { get; init; }
}