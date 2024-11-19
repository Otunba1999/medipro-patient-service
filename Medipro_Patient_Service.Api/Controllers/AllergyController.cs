using medipro_patient_service.Application.DTO;
using medipro_patient_service.Application.Interfaces.Sevices;
using medipro_patient_service.Domain.Models;

namespace medipro_patient_service.Api.Controllers;

public class AllergyController(IGenericService<Allergy> service) : GenericController<AllergyDto, Allergy>(service)
{
}

public class SubstancUseController(IGenericService<Allergy> service)
    : GenericController<AllergyDto, Allergy>(service)
{
}