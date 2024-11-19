using System.Text.Json.Serialization;

namespace medipro_patient_service.Domain.Models;

public class SexualHistory: Entity
{
    public bool SexuallyActive { get; init; }
    public string ContraceptionMethod { get; init; } = string.Empty;
    public int NumberOfPartners { get; init; }
    public bool HistoryOfSTIs { get; init; } = false;
    [JsonIgnore]
    public MedicalHistory? MedicalHistory { get; init; }
    public Guid MedicalHistoryId { get; set; }
}