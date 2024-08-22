namespace medipro_patient_service.Domain.Models;

public class Allergy : Entity
{
    public string Allergen { get; set; } = String.Empty;
    public string Reaction { get; set; } = String.Empty;
    public MedicalHistory? MedicalHistory { get; set; }
    public Guid MedicalHistoryId { get; set; }
    
}