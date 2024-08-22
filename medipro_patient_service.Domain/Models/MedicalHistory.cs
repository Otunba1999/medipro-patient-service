namespace medipro_patient_service.Domain.Models;

public class MedicalHistory : Entity
{
    public PresentIllness? PresentIllness { get; init; }
    public ICollection<Medication>? PastMedications { get; init; }
    public ICollection<Medication>? CurentMedications { get; init; }
    public ICollection<Allergy>? Allergies { get; init; }
    public ICollection<FamilyCondition>? FamilyConditions { get; init; }
    public ICollection<Immunization>? Immunizations { get; init; }
    public SubstanceUse? SubstanceUse { get; init; }
    public SexualHistory? SexualHistory { get; set; }
    public string LivingSituation { get; init; } = string.Empty;
    public string SocialSupport { get; init; } = string.Empty;
    public ReviewOfSystem? ReviewOfSystem { get; init; }
    public string MentalHealthCondition { get; init; } = string.Empty;
    public ICollection<Screening>? Screenings { get; init; }
    public ICollection<Vaccination>? Vaccinations { get; init; }
    public Patient? Patient { get; init; }
    public Guid PatientId { get; init; }
}