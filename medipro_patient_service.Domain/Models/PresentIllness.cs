namespace medipro_patient_service.Domain.Models;

public class PresentIllness : Entity
{
    public DateOnly OnsetDate { get; set; }
    public string Duration { get; set; } = String.Empty;
    public string Intensity { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public string AlliviatingFactor { get; set; } = String.Empty;
    public string ExacerbationFactors { get; set; } = String.Empty;
    public string AssociatedSypmtoms { get; set; } = String.Empty;
    public string PreviousEpisode { get; set; } = String.Empty;
    public MedicalHistory? MedicalHistory { get; set; }
    public Guid MedicalHistoryId { get; set; }
}