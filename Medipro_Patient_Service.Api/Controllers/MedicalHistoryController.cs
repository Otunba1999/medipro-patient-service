using medipro_patient_service.Application.DTO;
using medipro_patient_service.Application.Interfaces.Sevices;
using medipro_patient_service.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace medipro_patient_service.Api.Controllers;

public class MedicalHistoryController(IGenericService<MedicalHistory> service)
    : GenericController<UpdateMedicalHistory, MedicalHistory>(service)
{
    public override Task<IActionResult> AddAsync(UpdateMedicalHistory entity)
    {
        var response = new Dictionary<string, string> { { "Message", "Record already created" } };
        return Task.FromResult<IActionResult>(StatusCode(200, response));
    }
}