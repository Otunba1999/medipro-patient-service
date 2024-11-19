using System.Text.Json.Serialization;
using medipro_patient_service.Domain.Enums;

namespace medipro_patient_service.Domain.Models;

public class Medication : Entity
{
    public string Name { get; init; } = string.Empty;
    public string Dosage { get; init; } = string.Empty;
    public Frequency Frequency { get; init; }
    public DateOnly StartDate { get; init; }
    public DateOnly EndDate { get; init; }
    [JsonIgnore]
    public Patient? Patient { get; init; }
    public Guid PatientId { get; init; }
    [JsonIgnore]
    public MedicalHistory? MedicalHistory { get; init; }
    public Guid MedicalHistoryId { get; set; }
}