using System.Runtime.Serialization;

namespace medipro_patient_service.Domain.Enums;

public enum Gender
{
    [EnumMember(Value = "Male")]
    Male,
    [EnumMember(Value = "Female")]
    Female,
    [EnumMember(Value = "Other")]
    Other,
    [EnumMember(Value = "Prefer not to say")]
    Prefer_Not_To_Say
    
}