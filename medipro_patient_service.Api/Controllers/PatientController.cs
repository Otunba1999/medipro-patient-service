using medipro_patient_service.Application.Interfaces.Sevices;
using medipro_patient_service.Application.Patient.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace medipro_patient_service.Api.Controllers;

[Route("api/medipro/patient")]
[ApiController]
public class PatientController(IPatientService patientService) : ControllerBase
{
   [HttpPost("add")]
   public async Task<IActionResult> AddPatient([FromBody] BasicInfo basicInfo)
   {
      var response = await patientService.AddAsync(basicInfo);
      return StatusCode(response.StatusCode, response);
   }

   [HttpGet("get")]
   public async Task<IActionResult> GetAll()
   {
      var respone = await patientService.GetPatient();
      return StatusCode(200, respone);
   }
}