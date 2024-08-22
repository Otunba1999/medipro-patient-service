using medipro_patient_service.Domain.Models;

namespace medipro_patient_service.Domain.Models;

public class Contact : Entity
{
    public string Street { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public string State { get; init; } = string.Empty;
    public string Country { get; init; } = string.Empty;
    public string Phone { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public Patient? Patient { get; init; }
    public Guid PatientId { get; init; }
}