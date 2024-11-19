using System.Security.Claims;
using medipro_patient_service.Application.DTO;
using medipro_patient_service.Application.Interfaces.HttpService;
using medipro_patient_service.Application.Interfaces.Redis;
using medipro_patient_service.Application.Interfaces.Sevices;
using Medipro_Patient_Service.Common.Requests;
using Medipro_Patient_Service.Common.Responses;
using Medipro_Patient_Service.Infrastructure.HttpService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace medipro_patient_service.Api.Controllers;

[Route("api/medipro/patient")]
[ApiController]
[Authorize]
public class PatientController(
    IPatientService patientService,
    IRedisCachedService cached,
    ILogger<PatientController> logger) : ControllerBase
{
    [HttpPost("add")]
    public async Task<IActionResult> AddPatient([FromBody] BasicInfo basicInfo)
    {
        var response = await patientService.AddAsync(basicInfo);
        return StatusCode(response.StatusCode, response);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        Response<List<PatientDto>>? patients = await cached.GetData<Response<List<PatientDto>>>("patients");
        if (patients is not null) return StatusCode(200, patients);
        patients = await patientService.GetAllPatients();
        await cached.SetData("patients", patients);
        return StatusCode(200, patients);
    }

    [HttpGet]
    public async Task<IActionResult> GetPat()
    {
        var pat = await patientService.GetPatient();
        return StatusCode(200, pat);
    }

    [HttpPost("appointment")]
    public async Task<IActionResult> MakeAppointment([FromBody] AppointmentRequest request)
    {
        var token = await HttpContext.GetTokenAsync("access_token");
        if (string.IsNullOrEmpty(token))
            return Unauthorized();
        var response = await patientService.MakeAppointment(request, token);
        return StatusCode(200, response);
    }
}
