namespace medipro_patient_service.Domain.Models;

public class Illness : Entity
{
    public string Name { get; init; } = string.Empty;
    public DateOnly OnsetDate { get; init; }
    public DateOnly ResolutionDate { get; init; }
    public string Outcome { get; init; } = string.Empty;
    public PastMedicalHistory? PastMedicalHistory { get; init; }
    public Guid PastMedicalHistoryId { get; init; }
}