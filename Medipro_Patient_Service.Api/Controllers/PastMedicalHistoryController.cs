using medipro_patient_service.Application.DTO;
using medipro_patient_service.Application.Interfaces.Sevices;
using medipro_patient_service.Domain.Models;

namespace medipro_patient_service.Api.Controllers;

public class PastMedicalHistoryController(IGenericService<PastMedicalHistory> service) : GenericController<PastMedicalHistoryDto, PastMedicalHistory>(service)
{
}
public class SurgeryController(IGenericService<Surgery> service) : GenericController<SurgeryDto, Surgery>(service)
{
}
public class InjuryController(IGenericService<Injury> service) : GenericController<InjuryDto, Injury>(service)
{
}
public class IllnessController(IGenericService<Illness> service) : GenericController<IllnessDto, Illness>(service)
{
}
public class ChronicConditionController(IGenericService<ChronicCondition> service) : GenericController<ChronicConditionDto, ChronicCondition>(service)
{
}