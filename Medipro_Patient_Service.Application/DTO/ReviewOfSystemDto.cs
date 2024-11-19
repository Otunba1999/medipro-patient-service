namespace medipro_patient_service.Application.DTO;

public class ReviewOfSystemDto : BaseDto
{
    public string General { get; init; } = string.Empty;
    public string Neurological { get; init; } = string.Empty;
    public string Cardiovascular { get; init; } = string.Empty;
    public string Respiratory { get; init; } = string.Empty;
    public string GastroIntestinal { get; init; } = string.Empty;
    public string Musculskeletal { get; init; } = string.Empty;
    
}