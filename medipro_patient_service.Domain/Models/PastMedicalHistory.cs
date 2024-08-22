namespace medipro_patient_service.Domain.Models;

public class PastMedicalHistory : Entity
{
    public ICollection<ChronicCondition>? ChronicConditions { get; init; }
    public ICollection<Surgery>? Surgeries { get; init; }
    public ICollection<Illness>? Illnesses { get; init; }
    public ICollection<Injury>? Injuries { get; init; }
    public Patient? Patient { get; init; }
    public Guid PatientId { get; init; }
}