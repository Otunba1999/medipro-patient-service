using medipro_patient_service.Application.DTO;
using medipro_patient_service.Application.Interfaces.Sevices;
using medipro_patient_service.Domain.Models;

namespace medipro_patient_service.Api.Controllers;

public class PresentIllnessController(IGenericService<PresentIllness> service):
    GenericController<PresentIllnessDto, PresentIllness>(service)
{
    
}