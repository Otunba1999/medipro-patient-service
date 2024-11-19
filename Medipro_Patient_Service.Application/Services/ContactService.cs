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

public class ContactService(
    IGenericRepository<Contact> repository,
    IUserDetailsHelper helper,
    IMapper mapper) : IGenericService<Contact>

{
    public async Task<Response<object>> AddAsync(BaseDto dto)
    {
        var contact = mapper.Map<Contact>(dto);
        var patientId = await helper.GetPatientId();
        if (string.IsNullOrEmpty(patientId))
            throw new Exception(TaskMessage.ExpMessage);
        contact.PatientId = new Guid(patientId);
        var result = await repository.AddAsync(contact);
        return new Response<object>()
        {
            StatusCode = 200,
            Message = TaskMessage.Success,
            Data = mapper.Map<ContactDto>(result)
        };
    }

    public async Task<Response<object>> UpdateAsync(BaseDto contactDto)
    {
        var existingContact = await repository.GetByIdAsync(contactDto.Id.ToString());
        if (existingContact is null)
            throw new Exception($"Contact does not exist");
        var updatedContact = mapper.Map<Contact>(contactDto);
        var result = await repository.UpdateAsync(updatedContact);
        return new Response<object>()
        {
            StatusCode = 200,
            Message = result ? TaskMessage.Success : TaskMessage.Fail,
            Data = result ? TaskMessage.RecordUpdateSuccess : TaskMessage.RecordUpdateFailure
        };
    }

    public async Task<Response<object>?> GetAsync()
    {
        var patientId = await helper.GetPatientId();
        var data = await repository
            .FindAsync(c => c.PatientId.ToString() == patientId);
        var dtos = mapper.Map<ContactDto>(data);
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