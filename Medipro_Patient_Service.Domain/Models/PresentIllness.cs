using System.Text.Json.Serialization;
using medipro_patient_service.Domain.Enums;

namespace medipro_patient_service.Domain.Models;

public class PresentIllness : Entity
{
    public DateOnly OnsetDate { get; init; }
    public string Duration { get; init; } = string.Empty;
    public Intensity Intensity { get; init; }
    public string Description { get; init; } = string.Empty;
    public string AlleviatingFactor { get; init; } = string.Empty;
    public string ExacerbationFactors { get; init; } = string.Empty;
    public string AssociatedSymptoms { get; init; } = string.Empty;
    public string PreviousEpisode { get; init; } = string.Empty;
    [JsonIgnore]
    public MedicalHistory? MedicalHistory { get; init; }
    public Guid MedicalHistoryId { get; set; }
}