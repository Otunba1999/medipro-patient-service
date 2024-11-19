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

public class MedicalHistoryService(
    IGenericRepository<MedicalHistory> repository,
    IUserDetailsHelper helper,
    IMapper mapper) : IGenericService<MedicalHistory>
{
    public Task<Response<object>> AddAsync(BaseDto dto)
    {
        var res = new Response<object>()
        {
            StatusCode = 200,
            Message = TaskMessage.Success,
            Data =  TaskMessage.RecordUpdateSuccess
        };
        return Task.FromResult(res);
    }

    public async Task<Response<object>> UpdateAsync(BaseDto dto)
    {
        var patientId = await helper.GetPatientId();
        var medHis = await repository.FindAsync(m => m.PatientId.ToString() == patientId);
        if (medHis is null) throw new InvalidOperationException(TaskMessage.ExpMessage);
        if (dto is UpdateMedicalHistory med)
        {
            medHis.SocialSupport = med.SocialSupport;
            medHis.LivingSituation = med.LivingSituation;
            medHis.MentalHealthCondition = med.MentalHealthCondition;
        }

        var result = await repository.UpdateAsync(medHis);
        return new Response<object>()
        {
            StatusCode = 200,
            Message = result ? TaskMessage.Success : TaskMessage.Fail,
            Data = result ? TaskMessage.RecordUpdateSuccess : TaskMessage.RecordUpdateFailure
        };
    }

    public async Task<Response<object>?> GetAsync()
    {
        var data = await repository.GetAllAsync();
        var dtos = data.Select(mapper.Map<MedicalHistory>).ToList();
        return new Response<object>()
        {
            StatusCode = 200,
            Message = TaskMessage.Success,
            Data = dtos
        };
    }

    public async Task<Response<object>> DeleteAsync(string id)
    {
        var entity = await repository.FindAsync(x => x.Id.ToString() == id);
        if (entity is null)
            throw new Exception(TaskMessage.ExpMessage);
        return new Response<object>()
        {
            StatusCode = 200,
            Message = TaskMessage.Success,
            Data = await repository.RemoveAsync(entity)
        };
    }
}