namespace medipro_patient_service.Domain.Models;

public class SubstanceUse : Entity
{
    public bool Smokes { get; init; }
    public int CigPerDay { get; init; } = 0;
    public bool ConsumesAlcohol { get; init; }
    public string AlcoholConsuption { get; init; } = string.Empty;
    public bool UseRecreationalDrugs { get; init; }
    public string DrugType { get; init; } = string.Empty;
    public MedicalHistory? MedicalHistory { get; init; }
    public Guid MedicalHistoryId { get; init; }
}