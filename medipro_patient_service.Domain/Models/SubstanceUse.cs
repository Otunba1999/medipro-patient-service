namespace medipro_patient_service.Domain.Models;

public class SubstanceUse : Entity
{
    public bool Smokes { get; set; }
    public int CigPerDay { get; set; } = 0;
    public bool ConsumesAlcohol { get; set; }
    public string AlcoholConsuption { get; set; } = String.Empty;
    public bool UseRecreationalDrugs { get; set; }
    public string DrugType { get; set; } = string.Empty;
    public MedicalHistory? MedicalHistory { get; set; }
    public Guid MedicalHistoryId { get; set; }
}