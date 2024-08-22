namespace medipro_patient_service.Domain.Models;

public class Surgery : Entity
{
    public string Procedure { get; init; } = string.Empty;
    public DateOnly Date { get; init; }
    public string Hospital { get; init; } = string.Empty;
    public string Outcome { get; init; } = string.Empty;
    public PastMedicalHistory? PastMedicalHistory { get; init; }
    public Guid PastMedicalHistoryId { get; init; }
}