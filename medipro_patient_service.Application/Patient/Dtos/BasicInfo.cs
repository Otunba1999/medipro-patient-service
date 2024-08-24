using medipro_patient_service.Domain.Enums;

namespace medipro_patient_service.Application.Patient.Dtos;

public class BasicInfo
{
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public DateOnly DateOfBirth { get; init; }
    public string Occupation { get; init; } = string.Empty;
    public string LifeStyle { get; init; } = string.Empty;
    public Gender Gender { get; init; }
}