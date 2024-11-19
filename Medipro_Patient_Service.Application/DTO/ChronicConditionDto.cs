namespace medipro_patient_service.Application.DTO;

public class ChronicConditionDto : BaseDto
{
    public string Name { get; init; } = string.Empty;
    public DateOnly DiagonoseDate { get; init; }
    public string? Status { get; init; } = string.Empty;
}