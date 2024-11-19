using medipro_patient_service.Domain.Enums;

namespace medipro_patient_service.Application.DTO;

public  class PresentIllnessDto: BaseDto
{
    public DateOnly OnsetDate { get; init; }
    public string Duration { get; init; } = string.Empty;
    public string Intensity { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string AlleviatingFactor { get; init; } = string.Empty;
    public string ExacerbationFactors { get; init; } = string.Empty;
    public string AssociatedSymptoms { get; init; } = string.Empty;
    public string PreviousEpisode { get; init; } = string.Empty;
   
}