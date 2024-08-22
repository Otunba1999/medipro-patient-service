namespace medipro_patient_service.Domain.Models;

public class Screening : Entity
{
    public string Type { get; set; } = String.Empty;
    public DateOnly Date { get; set; }
    public string Result { get; set; } = String.Empty;
    public MedicalHistory? MedicalHistory { get; set; }
    public Guid MedicalHistoryId { get; set; }
}