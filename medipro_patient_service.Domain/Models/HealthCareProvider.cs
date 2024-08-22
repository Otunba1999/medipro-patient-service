namespace medipro_patient_service.Domain.Models;

public class HealthCareProvider : Entity
{
    public List<Patient>? Patients { get; init; }
}