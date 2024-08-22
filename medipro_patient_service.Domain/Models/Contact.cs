using medipro_patient_service.Domain.Models;

namespace medipro_patient_service.Domain.Models;

public class Contact : Entity
{
    public string Street { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public Patient? Patient { get; set; }
    public Guid PatientId { get; set; }
}