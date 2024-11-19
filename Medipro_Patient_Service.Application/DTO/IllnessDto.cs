using medipro_patient_service.Domain.Enums;

namespace medipro_patient_service.Application.DTO;

public class IllnessDto : BaseDto
{
    public string Name { get; init; } = string.Empty;
    public DateOnly OnsetDate { get; init; }
    public DateOnly ResolutionDate { get; init; }
    public string Outcome { get; init; } = string.Empty;
}