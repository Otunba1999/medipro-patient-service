namespace medipro_patient_service.Application.DTO;

public class SubstanceUseDto : BaseDto
{
    public bool Smokes { get; init; }
    public int CigPerDay { get; init; } = 0;
    public bool ConsumesAlcohol { get; init; }
    public string AlcoholConsuption { get; init; } = string.Empty;
    public bool UseRecreationalDrugs { get; init; }
    public string DrugType { get; init; } = string.Empty;
   
}