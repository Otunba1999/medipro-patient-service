using AutoMapper;
using medipro_patient_service.Application.DTO;
using medipro_patient_service.Application.Helper;
using Medipro_Patient_Service.Application.Interfaces.Helper;
using medipro_patient_service.Application.Interfaces.Repositories;
using medipro_patient_service.Application.Interfaces.Sevices;
using Medipro_Patient_Service.Common.Responses;
using Medipro_Patient_Service.Common.Utilities;
using medipro_patient_service.Domain.Models;
using Microsoft.Extensions.Logging;

namespace medipro_patient_service.Application.Services;

public class MedicationService(
    IGenericRepository<Domain.Models.Medication> repository,
    IUserDetailsHelper helper,
    // ILogger<Medication> logger,
    IMapper mapper) :MedHistoryGenericService<Medication, MedicationDto>(repository,helper, mapper)
{
}