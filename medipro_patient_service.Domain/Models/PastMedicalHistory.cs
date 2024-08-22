namespace medipro_patient_service.Domain.Models;

public class PastMedicalHistory : Entity
{
    public List<ChronicCondition>? ChronicConditions { get; set; }
    public List<Surgery>? Surgeries { get; set; }
    public List<Illness>? Illnesses { get; set; }
    public List<Injury>? Injuries { get; set; }
    public Patient? Patient { get; set; }
    public Guid PatientId { get; set; }
}