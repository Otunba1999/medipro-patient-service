using System.Text.Json.Serialization;
using medipro_patient_service.Application.Contact.Dtos;
using medipro_patient_service.Application.DTO;
using medipro_patient_service.Domain.Models;

namespace medipro_patient_service.Application.Patient.Dtos;

public class PatientDto : BaseDto
{
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public DateOnly DateOfBirth { get; init; }
    public string Gender { get; init; } = string.Empty;
    public ContactDto? Contact { get; init; }
    public string Occupation { get; init; } = string.Empty;
    public string LifeStyle { get; init; } = string.Empty;
    
    public MedicalHistory? MedicalHistory { get; init; }
    public PastMedicalHistory? PastMedicalHistory { get; init; }
    public ICollection<Medication>? CurrentMedications { get; init; }
    // public HealthCareProvider? HealthCareProvider { get; init; }
    // public Guid HealthCareProviderId { get; init; }
    public string UserId { get; init; } = string.Empty;
}