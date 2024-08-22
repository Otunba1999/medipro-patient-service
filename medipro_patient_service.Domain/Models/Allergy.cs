namespace medipro_patient_service.Domain.Models;

public class Allergy : Entity
{
    public string Allergen { get; init; } = string.Empty;
    public string Reaction { get; init; } = string.Empty;
    public MedicalHistory? MedicalHistory { get; init; }
    public Guid MedicalHistoryId { get; init; }
    
}