using System.Runtime.Serialization;

namespace medipro_patient_service.Domain.Enums;

public enum Frequency
{
    [EnumMember(Value = "Once Daily")]
    OnceDaily,
    [EnumMember(Value = "Twice Daily")]
    TwiceDaily,
    [EnumMember(Value = "Three Times Daily")]
    ThreeTimesDaily,
    [EnumMember(Value = "Four Times Daily")]
    FourTimesDaily,
    [EnumMember(Value = "Every 4 Hours")]
    Every4Hours,
    [EnumMember(Value = "Every 6 Hours")]
    Every6Hours,
    [EnumMember(Value = "Every 8 Hours")]
    Every8Hours,
    [EnumMember(Value = "As Needed")]
    AsNeeded,
    [EnumMember(Value = "Around The Clock")]
    AroundTheClock
    
}