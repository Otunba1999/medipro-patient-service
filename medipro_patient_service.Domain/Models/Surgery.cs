namespace medipro_patient_service.Domain.Models;

public class Surgery : Entity
{
    public string Procedure { get; set; } = String.Empty;
    public DateOnly Date { get; set; }
    public string Hospital { get; set; } = string.Empty;
    public string Outcome { get; set; } = String.Empty;
    public PastMedicalHistory? PastMedicalHistory { get; set; }
    public Guid PastMedicalHistoryId { get; set; }
}