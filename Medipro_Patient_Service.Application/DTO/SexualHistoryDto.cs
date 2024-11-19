namespace medipro_patient_service.Application.DTO;

public class SexualHistoryDto : BaseDto
{
    public bool SexuallyActive { get; init; }
    public string ContraceptionMethod { get; init; } = string.Empty;
    public int NumberOfPartners { get; init; }
    public bool HistoryOfSTIs { get; init; } = false;
   
}