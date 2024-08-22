namespace medipro_patient_service.Domain.Models;

public class ReviewOfSystem : Entity
{
    public string General { get; init; } = string.Empty;
    public string Neurological { get; init; } = string.Empty;
    public string Cardiovascular { get; init; } = string.Empty;
    public string Respiratory { get; init; } = string.Empty;
    public string GastroIntestinal { get; init; } = string.Empty;
    public string Musculskeletal { get; init; } = string.Empty;
    public MedicalHistory? MedicalHistory { get; init; }
    public Guid MedicalHistoryId { get; init; }
}