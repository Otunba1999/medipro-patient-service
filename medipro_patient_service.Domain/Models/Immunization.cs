namespace medipro_patient_service.Domain.Models;

public class Immunization : Entity
{
    public string VaccineName { get; set; } = String.Empty;
    public DateOnly DateAdministered { get; set; }
    public MedicalHistory? MedicalHistory { get; set; }
    public Guid MedicalHistoryId { get; set; }
}