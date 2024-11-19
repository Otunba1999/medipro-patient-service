using AutoMapper;
using medipro_patient_service.Application.DTO;
using medipro_patient_service.Application.Helper;
using Medipro_Patient_Service.Application.Interfaces.Helper;
using medipro_patient_service.Application.Interfaces.HttpService;
using medipro_patient_service.Application.Interfaces.Repositories;
using medipro_patient_service.Application.Interfaces.Sevices;
using Medipro_Patient_Service.Common.Requests;
using Medipro_Patient_Service.Common.Responses;
using Medipro_Patient_Service.Common.Utilities;
using medipro_patient_service.Domain.Models;
using Microsoft.Extensions.Logging;

namespace medipro_patient_service.Application.Services;

public class PatientService(
    IGenericRepository<Patient> patientRepository,
    IMapper mapper,
    IUserDetailsHelper helper,
    IHttpService<MailRequest> mailService,
    IHttpService<AppointmentRequest> appointmentService,
    ILogger<PatientService> logger,
    IGenericRepository<MedicalHistory> medicalHistoryRepository) : IPatientService
{
    public async Task<Response<BaseDto>> AddAsync(BasicInfo basicInfo)
    {
        var user = helper.GetUserDetail();
        if (user is null) throw new Exception(TaskMessage.ExpMessage);
        var exist = await patientRepository.FindAsync(p => p.UserId == user.UserId) is not null;
        if (exist)
        {
            logger.LogInformation("Patient already exist");
            throw new InvalidOperationException("Record already exist");
        }
        var patient = new Patient()
        {
            FirstName = basicInfo.FirstName,
            LastName = basicInfo.LastName,
            Gender = basicInfo.Gender,
            DateOfBirth = basicInfo.DateOfBirth,
            Occupation = basicInfo.Occupation,
            LifeStyle = basicInfo.LifeStyle,
            UserId = user.UserId
        };
        var result = await patientRepository.AddAsync(patient);
        logger.LogInformation("Creating new patient in the database");
        var medicalHistory = new MedicalHistory()
        {
            PatientId = result.Id
        };
        await medicalHistoryRepository.AddAsync(medicalHistory);
        logger.LogInformation("Creating medical history for patient");
        var request = new MailRequest
        {
            Recipient = user.Email,
            Content = "You successfully create a patient record",
            Subject = "Patient record created"
        };
        var response = await mailService.Add(request, "send-simple-message");
        var patientDto = mapper.Map<PatientDto>(result);
        return new Response<BaseDto>()
        {
            StatusCode = 200,
            Message = TaskMessage.Success,
            Data = patientDto
        };
    }

    public async Task<Response<List<PatientDto?>>> GetAllPatients()
    {
        var userDetail = helper.GetUserDetail();
        if (userDetail is null) throw new Exception(TaskMessage.ExpMessage);
        // var patient = await patientRepository.FindAsync(p => p.UserId == userDetail.UserId);
        logger.LogInformation("Getting all patient info");
        var result = await patientRepository.GetAllAsync(
            "Contact", "MedicalHistory", "PastMedicalHistory");
        var patients = result.ToList();
        var patientDtos = patients.Select(mapper.Map<PatientDto>).ToList();
        return new Response<List<PatientDto?>>()
        {
            StatusCode = 200,
            Message = TaskMessage.Success,
            Data = patientDtos!
        };
    }

    public async Task<Response<object>> GetPatient()
    {
        var userDetail = helper.GetUserDetail();
        var includeProperties = new[]
        {
            "MedicalHistory.Allergies", "MedicalHistory.FamilyConditions",
            "MedicalHistory.SubstanceUse", "MedicalHistory.SexualHistory",
            "MedicalHistory.Screenings", "MedicalHistory.Vaccinations",
            "MedicalHistory.PresentIllness", "MedicalHistory.CurrentMedications",
            "MedicalHistory.PastMedications", "MedicalHistory.ReviewOfSystem",
            "MedicalHistory.Immunizations", "Contact", "PastMedicalHistory.Injuries",
            "PastMedicalHistory.ChronicConditions", "PastMedicalHistory.Surgeries", 
            "PastMedicalHistory.Illnesses"
        };
        var patient = await patientRepository
            .FindAndIncludeAsync(p => p.UserId == userDetail.UserId, includeProperties
            );
        var pat = patient.FirstOrDefault(p => p.UserId == userDetail.UserId);
        logger.LogInformation("Getting  patient info");
        var patientDto = mapper.Map<PatientDto>(pat);
        return new Response<object>()
        {
            StatusCode = 200,
            Message = TaskMessage.Success,
            Data = patientDto
        };
    }

    public async Task<Response<object>> MakeAppointment(AppointmentRequest request, string token)
    {
        var headers = new Dictionary<string, string> { { "Authorization", token } };
        var response = await appointmentService.Add(request, "appointment", headers);
        return response;
    }
}