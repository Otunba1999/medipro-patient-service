using AutoMapper;
using medipro_patient_service.Application.DTO;
using medipro_patient_service.Application.Helper;
using Medipro_Patient_Service.Application.Interfaces.Helper;
using medipro_patient_service.Application.Interfaces.Repositories;
using medipro_patient_service.Domain.Models;

namespace medipro_patient_service.Application.Services;

public class IllnessService(
    IGenericRepository<Illness> repository,
    IUserDetailsHelper helper,
    IMapper mapper): PastMedHistoryGenericService<Illness, IllnessDto>(repository, helper, mapper)
{
    
}