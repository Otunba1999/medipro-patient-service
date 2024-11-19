using System.Text.Json.Serialization;

namespace medipro_patient_service.Domain.Models;

public class Vaccination : Entity
{
    public string VaccineName { get; init; } = string.Empty;
    public DateOnly  DateAdministered { get; init; }
    public string Manufacturer { get; init; } = string.Empty;
    public string BatchNumber { get; init; } = string.Empty;
    [JsonIgnore]
    public MedicalHistory? MedicalHistory { get; init; }
    public Guid MedicalHistoryId { get; set; }
}