namespace medipro_patient_service.Domain.Models;

public class Injury : Entity
{
    public string Description { get; init; } = string.Empty;
    public DateOnly Date { get; init; }
    public string Treatment { get; init; } = string.Empty;
    public string Outcome { get; init; } = string.Empty;
    public PastMedicalHistory? PastMedicalHistory { get; init; }
    public Guid PastMedicalHistoryId { get; init; }
}// 33DE-826B