using System.Runtime.Serialization;

namespace medipro_patient_service.Domain.Enums;

public enum SurgeryOutcome
{
    [EnumMember(Value = "Successful")]
    Successful,
    [EnumMember(Value = "Complications")]
    Complications,
    [EnumMember(Value = "Mortality")]
    Mortality,
    [EnumMember(Value = "No Improvement")]
    NoImprovement,
    [EnumMember(Value = "Partial Success")]
    PartialSuccess,
    [EnumMember(Value = "Unfavourable Outcome")]
    UnFavourableOutcome,
    
}