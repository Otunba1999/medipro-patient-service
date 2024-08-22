namespace medipro_patient_service.Domain.Models;

public class Vaccination
{
    public string VaccineName { get; init; } = string.Empty;
    public DateOnly  DateAdministered { get; init; }
    public string Manufacturer { get; init; } = string.Empty;
    public string BatchNumber { get; init; } = string.Empty;
    public MedicalHistory? MedicalHistory { get; init; }
    public Guid MedicalHistoryId { get; init; }
}