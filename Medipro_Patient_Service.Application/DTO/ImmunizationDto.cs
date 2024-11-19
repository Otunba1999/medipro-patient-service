namespace medipro_patient_service.Application.DTO;

public  class ImmunizationDto : BaseDto
{
    public string VaccineName { get; init; } = string.Empty;
    public DateOnly DateAdministered { get; init; }
    
}