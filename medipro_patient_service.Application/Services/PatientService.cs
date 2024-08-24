using AutoMapper;
using medipro_patient_service.Application.Contact.Dtos;
using medipro_patient_service.Application.DTO;
using medipro_patient_service.Application.Interfaces.Repositories;
using medipro_patient_service.Application.Interfaces.Sevices;
using medipro_patient_service.Application.Patient.Dtos;
using Medipro_Patient_Service.Common.Responses;
using medipro_patient_service.Domain.Models;

namespace medipro_patient_service.Application.Services;

public class PatientService(IGenericRepository<Domain.Models.Patient> patientRepository, IMapper mapper) : IPatientService
{
    public async Task<Response<BaseDto>> AddAsync(BasicInfo basicInfo)
    {
        var patient = new Domain.Models.Patient()
        {
            FirstName = basicInfo.FirstName,
            LastName = basicInfo.LastName,
            Gender = basicInfo.Gender,
            DateOfBirth = basicInfo.DateOfBirth,
            Occupation = basicInfo.Occupation,
            LifeStyle = basicInfo.LifeStyle
        };
       var result = await patientRepository.AddAsync(patient);
       var patientDto = mapper.Map<PatientDto>(result);
       return new Response<BaseDto>()
       {
           StatusCode = 200,
           Message = "Operation successful",
           Data = patientDto
       };
    }

    public async Task<Response<List<PatientDto?>>> GetPatient()
    {
        var result = await patientRepository.GetAllAsync("Contact");
        var patients =  result.ToList();
        var patientDtos = patients.Select(p =>
        {
            // var contactDto = mapper.Map<ContactDto>(p.Contact);
            return new PatientDto()
            {
                FirstName = p.FirstName,
                LastName = p.LastName,
                DateOfBirth = p.DateOfBirth,
                Gender = p.Gender.ToString(),
                Contact = mapper.Map<ContactDto>(p.Contact),
                Occupation = p.Occupation,
                LifeStyle = p.LifeStyle,
                MedicalHistory = p.MedicalHistory,
                PastMedicalHistory = p.PastMedicalHistory,
                CurrentMedications = p.CurrentMedications,
                Id = p.Id,
                // UserId = p.UserId
            };
        }).ToList();
        return new Response<List<PatientDto?>>()
        {
            StatusCode = 200,
            Message = "Operation successful",
            Data = patientDtos!
        };
    }
}