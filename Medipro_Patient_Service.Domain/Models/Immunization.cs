using System.Text.Json.Serialization;

namespace medipro_patient_service.Domain.Models;

public class Immunization : Entity
{
    public string VaccineName { get; init; } = string.Empty;
    public DateOnly DateAdministered { get; init; }
    [JsonIgnore]
    public MedicalHistory? MedicalHistory { get; init; }
    public Guid MedicalHistoryId { get; set; }
}