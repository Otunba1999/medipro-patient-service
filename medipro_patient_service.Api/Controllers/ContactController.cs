using medipro_patient_service.Application.Contact.Dtos;
using medipro_patient_service.Application.Interfaces.Sevices;
using medipro_patient_service.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace medipro_patient_service.Api.Controllers;

[Route("api/medipro/contact")]
[ApiController]
public class ContactController(IGenericService<Contact> service) : ControllerBase
{
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] ContactDto contactDto)
    {
        var result = await service.AddAsync(contactDto);
        return StatusCode(result.StatusCode, result);
    }
}