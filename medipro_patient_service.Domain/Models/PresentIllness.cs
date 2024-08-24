namespace medipro_patient_service.Domain.Models;

public class PresentIllness : Entity
{
    public DateOnly OnsetDate { get; init; }
    public string Duration { get; init; } = string.Empty;
    public string Intensity { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string AlleviatingFactor { get; init; } = string.Empty;
    public string ExacerbationFactors { get; init; } = string.Empty;
    public string AssociatedSymptoms { get; init; } = string.Empty;
    public string PreviousEpisode { get; init; } = string.Empty;
    public MedicalHistory? MedicalHistory { get; init; }
    public Guid MedicalHistoryId { get; init; }
}