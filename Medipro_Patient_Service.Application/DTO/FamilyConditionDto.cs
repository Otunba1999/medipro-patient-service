namespace medipro_patient_service.Application.DTO;

public class FamilyConditionDto : BaseDto
{
    public string Condition { get; init; } = string.Empty;
    public string Relative { get; init; } = string.Empty;
    
}