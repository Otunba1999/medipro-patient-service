using AutoMapper;
using medipro_patient_service.Application.DTO;
using medipro_patient_service.Application.Helper;
using Medipro_Patient_Service.Application.Interfaces.Helper;
using medipro_patient_service.Application.Interfaces.Repositories;
using medipro_patient_service.Application.Interfaces.Sevices;
using Medipro_Patient_Service.Common.Responses;
using Medipro_Patient_Service.Common.Utilities;
using medipro_patient_service.Domain.Models;

namespace medipro_patient_service.Application.Services;

public class PastMedicalHistoryService(
    IGenericRepository<PastMedicalHistory> repository,
    IUserDetailsHelper helper,
    IMapper mapper) : IGenericService<PastMedicalHistory>
{
    public async Task<Response<object>> AddAsync(BaseDto dto)
    {
        var patientId = await helper.GetPatientId();
        var exist = await repository.FindAsync(p => p.PatientId.ToString() == patientId) is not null;
        if (exist) throw new InvalidOperationException("History already exist");
        if (string.IsNullOrEmpty(patientId)) throw new Exception(TaskMessage.ExpMessage);
        var medHistory = mapper.Map<PastMedicalHistory>(dto);
        medHistory.PatientId = new Guid(patientId);
        var result = await repository.AddAsync(medHistory);
        return new Response<object>
        {
            StatusCode = 200,
            Message = TaskMessage.Success,
            Data = mapper.Map<PastMedicalHistoryDto>(result)
        };

    }

    public Task<Response<object>> UpdateAsync(BaseDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<Response<object>?> GetAsync()
    {
        var patientId = await helper.GetPatientId();
        var history = await repository.FindAndIncludeAsync
        (p => p.PatientId.ToString() == patientId,
            "Injuries", "ChronicConditions", "Surgeries", "Illnesses");
        var his = history.FirstOrDefault(p => p.PatientId.ToString() == patientId);
        var dto = mapper.Map<PastMedicalHistoryDto>(his);
        return new Response<object>()
        {
            StatusCode = 200,
            Message = TaskMessage.Success,
            Data = dto
        };

    }

    public Task<Response<object>> DeleteAsync(string id)
    {
        throw new NotImplementedException();
    }
}