using System.Text.Json.Serialization;

namespace medipro_patient_service.Domain.Models;

public class Screening : Entity
{
    public string Type { get; init; } = string.Empty;
    public DateOnly Date { get; init; }
    public string Result { get; init; } = string.Empty;
    [JsonIgnore]
    public MedicalHistory? MedicalHistory { get; init; }
    public Guid MedicalHistoryId { get; set; }
}