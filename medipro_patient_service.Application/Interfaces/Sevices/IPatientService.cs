using medipro_patient_service.Application.DTO;
using medipro_patient_service.Application.Patient.Dtos;
using Medipro_Patient_Service.Common.Responses;
using medipro_patient_service.Domain.Models;

namespace medipro_patient_service.Application.Interfaces.Sevices;

/// <summary>
/// A service interface use for managing the patient 
/// </summary>
public interface IPatientService
{
    /// <summary>
    /// add the basic information of patient to the repository
    /// </summary>
    /// <param name="basicInfo">receives the basic info of the patient.</param>
    /// <returns>returns a generic response</returns>
    Task<Response<BaseDto?>> AddAsync(BasicInfo basicInfo);
    /// <summary>
    /// get all patient from the database
    /// </summary>
    /// <returns>returns list of PatientDto</returns>
    Task<Response<List<PatientDto?>>> GetPatient();
}