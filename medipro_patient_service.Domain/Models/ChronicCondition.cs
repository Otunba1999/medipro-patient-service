namespace medipro_patient_service.Domain.Models;

public class ChronicCondition : Entity
{
    public string Name { get; init; } = string.Empty;
    public DateOnly DiagonoseDate { get; init; }
    public string? Status { get; init; } = string.Empty;
    public PastMedicalHistory? PastMedicalHistory { get; init; }
    public Guid PastMedicalHistoryId { get; init; }
}