using System.Runtime.Serialization;

namespace medipro_patient_service.Domain.Enums;

public enum IllnessOutcome
{
    [EnumMember(Value = "Recovered")]
    Recovered,
    [EnumMember(Value = "Chronic Condition")]
    ChronicCondition,
    [EnumMember(Value = "Partial Recovery")]
    PartialRecovery,
    [EnumMember(Value = "Dependency")]
    Dependency,
    [EnumMember(Value = "Quality Of Life Impairment")]
    QualityOfLifeImpairment,
    [EnumMember(Value = "Mortality")]
    Mortality,
    [EnumMember(Value = "Adverse Outcome")]
    AdverseOutcome,
    
}