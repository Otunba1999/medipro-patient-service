namespace medipro_patient_service.Domain.Models;

public class ReviewOfSystem : Entity
{
    public string General { get; set; } = String.Empty;
    public string Neurological { get; set; } = String.Empty;
    public string Cardiovascular { get; set; } = String.Empty;
    public string Respiratory { get; set; } = String.Empty;
    public string GastroIntestinal { get; set; } = String.Empty;
    public string Musculskeletal { get; set; } = String.Empty;
    public MedicalHistory? MedicalHistory { get; set; }
    public Guid MedicalHistoryId { get; set; }
}