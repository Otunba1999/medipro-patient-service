using System.Runtime.Serialization;

namespace medipro_patient_service.Domain.Enums;

public enum Intensity
{
    [EnumMember(Value = "None")]
    None,
    [EnumMember(Value = "Minor")]
    Minor,
    [EnumMember(Value = "Moderate")]
    Moderate,
    [EnumMember(Value = "Major")]
    Major,
    [EnumMember(Value = "Extreme")]
    Extreme,
    
}