using medipro_patient_service.Application.DTO;
using medipro_patient_service.Application.Interfaces.Sevices;
using medipro_patient_service.Domain.Models;

namespace medipro_patient_service.Api.Controllers;

public class FamilyConditionController(IGenericService<FamilyCondition> service)
    : GenericController<FamilyConditionDto, FamilyCondition>(service)
{
    
}