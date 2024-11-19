using System.Linq.Expressions;
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

public class MedHistoryGenericService<T, TD>(
    IGenericRepository<T> repository,
    IUserDetailsHelper helper,
    // ILogger<T> logger,
    IMapper mapper) : IGenericService<T> where T : Entity where TD : BaseDto
{
    public async Task<Response<object>> AddAsync(BaseDto dto)
    {
        var medHisoryId = await helper.GetMedHistoryId();
        dynamic entity = mapper.Map<T>(dto);
        if (string.IsNullOrEmpty(medHisoryId))
            throw new Exception(TaskMessage.ExpMessage);
        entity.MedicalHistoryId = new Guid(medHisoryId);
        var result = await repository.AddAsync(entity);
        // logger.LogInformation($"Inserting new {typeof(T).Name} in the database");
        return new Response<object>()
        {
            StatusCode = 200,
            Message = TaskMessage.Success,
            Data = mapper.Map<TD>(result)
        };
    }

    public async Task<Response<object>> UpdateAsync(BaseDto dto)
    {
        var existingEntity = await repository.GetByIdAsync(dto.Id.ToString());
        if (existingEntity is null)
            throw new Exception(TaskMessage.ExpMessage);
        var updatedEntity = mapper.Map<T>(dto);
        var result = await repository.UpdateAsync(updatedEntity);
        // logger.LogInformation($"Updating {typeof(T).Name} in the database");
        return new Response<object>()
        {
            StatusCode = 200,
            Message = result ? TaskMessage.Success : TaskMessage.Fail,
            Data = result ? TaskMessage.RecordUpdateSuccess : TaskMessage.RecordUpdateFailure
        };
    }

    public async Task<Response<object>?> GetAsync()
    {
        var medHisId = new Guid(await helper.GetMedHistoryId()!);
        // Create parameter expression for entity type
        var parameter = Expression.Parameter(typeof(T), "x");
        // Create property access expression for MedicalHistoryId
        var property = Expression.Property(parameter, "MedicalHistoryId");
        // Create constant expression for medHisId
        var constant = Expression.Constant(medHisId);
        // Create equality expression (x.MedicalHistoryId == medHisId)
        var eqaulity = Expression.Equal(property, constant);
        // Create lambda expression (x => x,MedicalHistoryId == medHisId)
        var lambda = Expression.Lambda<Func<T, bool>>(eqaulity, parameter);
        var data = await repository.FindAndIncludeAsync(lambda);
        var dtos = data.Select(mapper.Map<TD>).ToList();
        // logger.LogInformation($"Getting {typeof(T).Name} info from the database");
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
        // logger.LogInformation($"Deleting {typeof(T).Name} from the database");
        return new Response<object>()
        {
            StatusCode = 200,
            Message = TaskMessage.Success,
            Data = await repository.RemoveAsync(entity)
        };
    }
    
}