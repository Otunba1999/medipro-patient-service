using medipro_patient_service.Application.DTO;
using medipro_patient_service.Application.Interfaces.Sevices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace medipro_patient_service.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize]
public class GenericController<T, TE>(IGenericService<TE> service) : Controller where T : BaseDto where TE : class
{
    [HttpPost]
    public virtual async Task<IActionResult> AddAsync([FromBody] T entity)
    {
        return !ModelState.IsValid ? BadRequest(ModelState) : StatusCode(200, await service.AddAsync(entity));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] T entity)
    {
        return !ModelState.IsValid ? BadRequest(ModelState) : StatusCode(200, await service.UpdateAsync(entity));
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        return StatusCode(200, await service.GetAsync());
    }
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        return StatusCode(200, await service.DeleteAsync(id.ToString()));
    }
    
}