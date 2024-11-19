using System.Text.Json.Serialization;

namespace medipro_patient_service.Domain.Models;

public class MedicalHistory : Entity
{
    public PresentIllness? PresentIllness { get; init; }
    public ICollection<Medication>? PastMedications { get; init; }
    public ICollection<Medication>? CurrentMedications { get; init; }
    public ICollection<Allergy>? Allergies { get; init; }
    public ICollection<FamilyCondition>? FamilyConditions { get; init; }
    public ICollection<Immunization>? Immunizations { get; init; }
    public SubstanceUse? SubstanceUse { get; init; }
    public SexualHistory? SexualHistory { get; init; }
    public string LivingSituation { get; set; } = string.Empty;
    public string SocialSupport { get; set; } = string.Empty;
    public ReviewOfSystem? ReviewOfSystem { get; init; }
    public string MentalHealthCondition { get; set; } = string.Empty;
    public ICollection<Screening>? Screenings { get; init; }
    public ICollection<Vaccination>? Vaccinations { get; init; }
    [JsonIgnore]
    public Patient? Patient { get; init; }
    public Guid PatientId { get; init; }
}