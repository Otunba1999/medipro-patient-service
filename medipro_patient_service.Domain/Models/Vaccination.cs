namespace medipro_patient_service.Domain.Models;

public class Vaccination
{
    public string Vaccinename { get; set; } = String.Empty;
    public DateOnly  DateAdministred { get; set; }
    public string Manufacturer { get; set; } = String.Empty;
    public string BatchNumber { get; set; } = string.Empty;
    public MedicalHistory? MedicalHistory { get; set; }
    public Guid MedicalHistoryId { get; set; }
}