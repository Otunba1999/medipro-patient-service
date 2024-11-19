using medipro_patient_service.Domain.Enums;

namespace medipro_patient_service.Application.DTO;

public class SurgeryDto : BaseDto
{
    public string Procedure { get; init; } = string.Empty;
    public DateOnly Date { get; init; }
    public string Hospital { get; init; } = string.Empty;
    public string Outcome { get; init; } = string.Empty;
}