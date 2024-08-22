namespace medipro_patient_service.Domain.Models;

public class Illness : Entity
{
    public string Name { get; set; } = String.Empty;
    public DateOnly OnsetDate { get; set; }
    public DateOnly ResolutionDate { get; set; }
    public string Outcome { get; set; } = String.Empty;
    public PastMedicalHistory? PastMedicalHistory { get; set; }
    public Guid PastMedicalHistoryId { get; set; }
}