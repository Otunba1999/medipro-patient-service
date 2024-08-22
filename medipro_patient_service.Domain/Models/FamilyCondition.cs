namespace medipro_patient_service.Domain.Models;

public class FamilyCondition : Entity
{
    public string Condition { get; set; } = String.Empty;
    public string Relative { get; set; } = String.Empty;
    public MedicalHistory? MedicalHistory { get; set; }
    public Guid MedicalHistoryId { get; set; }
}