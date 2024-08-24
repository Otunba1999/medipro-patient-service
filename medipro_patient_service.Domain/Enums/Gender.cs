using System.Runtime.Serialization;

namespace medipro_patient_service.Domain.Enums;

public enum Gender
{
    [EnumMember(Value = "Male")]
    Male = 0,
    [EnumMember(Value = "Female")]
    Female = 1,
    [EnumMember(Value = "Other")]
    Other = 2,
    [EnumMember(Value = "Prefer not to say")]
    PreferNotToSay = 4
    
}