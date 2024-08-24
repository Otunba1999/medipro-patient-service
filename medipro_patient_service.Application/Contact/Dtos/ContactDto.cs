using medipro_patient_service.Application.DTO;

namespace medipro_patient_service.Application.Contact.Dtos;

public class ContactDto : BaseDto
{
    public string Street { get; init; } = string.Empty;
    public string City { get; init; } = string.Empty;
    public string State { get; init; } = string.Empty;
    public string Country { get; init; } = string.Empty;
    public string Phone { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
    public Guid PatientId { get; init; }
}