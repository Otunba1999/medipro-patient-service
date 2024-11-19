using medipro_patient_service.Domain.Enums;

namespace medipro_patient_service.Application.DTO;

public class InjuryDto : BaseDto
{
    public string Description { get; init; } = string.Empty;
    public DateOnly Date { get; init; }
    public string Treatment { get; init; } = string.Empty;
    public string Outcome { get; init; } = string.Empty;
}