using System.Text.Json.Serialization;
using medipro_patient_service.Domain.Enums;

namespace medipro_patient_service.Domain.Models;

public class Illness : Entity
{
    public string Name { get; init; } = string.Empty;
    public DateOnly OnsetDate { get; init; }
    public DateOnly ResolutionDate { get; init; }
    public IllnessOutcome Outcome { get; init; }
    [JsonIgnore]
    public PastMedicalHistory? PastMedicalHistory { get; init; }
    public Guid PastMedicalHistoryId { get; set; }
}