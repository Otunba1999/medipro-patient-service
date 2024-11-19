using System.Text.Json.Serialization;
using medipro_patient_service.Domain.Enums;

namespace medipro_patient_service.Domain.Models;

public class Surgery : Entity
{
    public string Procedure { get; init; } = string.Empty;
    public DateOnly Date { get; init; }
    public string Hospital { get; init; } = string.Empty;
    public SurgeryOutcome Outcome { get; init; }
    [JsonIgnore]
    public PastMedicalHistory? PastMedicalHistory { get; init; }
    public Guid PastMedicalHistoryId { get; set; }
}