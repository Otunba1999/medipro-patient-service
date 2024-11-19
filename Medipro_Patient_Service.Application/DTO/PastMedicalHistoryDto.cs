namespace medipro_patient_service.Application.DTO;

public class PastMedicalHistoryDto : BaseDto
{
    public ICollection<ChronicConditionDto>? ChronicConditions { get; init; }
    public ICollection<SurgeryDto>? Surgeries { get; init; }
    public ICollection<IllnessDto>? Illnesses { get; init; }
    public ICollection<InjuryDto>? Injuries { get; init; }
}