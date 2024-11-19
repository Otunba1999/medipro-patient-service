namespace medipro_patient_service.Application.DTO;

public class ScreeningDto : BaseDto
{
    public string Type { get; init; } = string.Empty;
    public DateOnly Date { get; init; }
    public string Result { get; init; } = string.Empty;
    
}