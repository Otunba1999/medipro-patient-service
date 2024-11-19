using System.Text.Json.Serialization;

namespace medipro_patient_service.Domain.Models;

public class ChronicCondition : Entity
{
    public string Name { get; init; } = string.Empty;
    public DateOnly DiagonoseDate { get; init; }
    public string? Status { get; init; } = string.Empty;
    [JsonIgnore]
    public PastMedicalHistory? PastMedicalHistory { get; init; }
    public Guid PastMedicalHistoryId { get; set; }
}