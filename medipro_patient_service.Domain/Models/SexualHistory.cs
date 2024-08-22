namespace medipro_patient_service.Domain.Models;

public class SexualHistory: Entity
{
    public bool SexuallyActive { get; set; }
    public string ContraceptionMethod { get; set; } = String.Empty;
    public int NumberOfPartners { get; set; }
    public bool HistoryOfSTIs { get; set; }
    public MedicalHistory? MedicalHistory { get; set; }
    public Guid MedicalHistoryId { get; set; }
}