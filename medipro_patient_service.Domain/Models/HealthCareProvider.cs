namespace medipro_patient_service.Domain.Models;

public class HealthCareProvider : Entity
{
    public ICollection<Patient>? Patients { get; init; }
}