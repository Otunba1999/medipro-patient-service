using AutoMapper;
using medipro_patient_service.Application.DTO;
using medipro_patient_service.Application.Helper;
using Medipro_Patient_Service.Application.Interfaces.Helper;
using medipro_patient_service.Application.Interfaces.Repositories;
using medipro_patient_service.Domain.Models;
using Microsoft.Extensions.Logging;

namespace medipro_patient_service.Application.Services;

public class FamilyConditionService(
    IGenericRepository<FamilyCondition> repository,
    IUserDetailsHelper helper,
    // ILogger<FamilyCondition> logger,
    IMapper mapper) : MedHistoryGenericService<FamilyCondition, FamilyConditionDto>(repository, helper, mapper)
{
    
}