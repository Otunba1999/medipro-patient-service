namespace medipro_patient_service.Application.DTO;

public class AllergyDto : BaseDto
{
    public string Allergen { get; init; } = string.Empty;
    public string Reaction { get; init; } = string.Empty;
    
}