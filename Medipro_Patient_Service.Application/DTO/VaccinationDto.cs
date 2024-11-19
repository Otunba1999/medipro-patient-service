namespace medipro_patient_service.Application.DTO;

public class VaccinationDto : BaseDto
{
    public string VaccineName { get; init; } = string.Empty;
    public DateOnly DateAdministered { get; init; }
    public string Manufacturer { get; init; } = string.Empty;
    public string BatchNumber { get; init; } = string.Empty;
}