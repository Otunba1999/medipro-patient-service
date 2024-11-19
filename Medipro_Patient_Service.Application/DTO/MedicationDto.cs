using medipro_patient_service.Domain.Enums;

namespace medipro_patient_service.Application.DTO;

public class MedicationDto: BaseDto
{
    public string Name { get; init; } = string.Empty;
    public string Dosage { get; init; } = string.Empty;
    public string Frequency { get; init; } = string.Empty;
    public DateOnly StartDate { get; init; }
    public DateOnly EndDate { get; init; }
    public Guid PatientId { get; init; }
   
}