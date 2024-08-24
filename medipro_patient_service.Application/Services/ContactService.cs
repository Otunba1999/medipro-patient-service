using AutoMapper;
using medipro_patient_service.Application.Contact.Dtos;
using medipro_patient_service.Application.DTO;
using medipro_patient_service.Application.Interfaces.Repositories;
using medipro_patient_service.Application.Interfaces.Sevices;
using medipro_patient_service.Application.Patient.Dtos;
using Medipro_Patient_Service.Common.Responses;
using medipro_patient_service.Domain.Models;

namespace medipro_patient_service.Application.Services;

public class ContactService
    (IGenericRepository<Domain.Models.Contact> repository, IMapper mapper) : IGenericService<Domain.Models.Contact>
    
{
    public async Task<Response<object>> AddAsync(BaseDto dto)
    {
        var contact =  mapper.Map<Domain.Models.Contact>(dto);
        var result = await repository.AddAsync(contact);
        return new Response<object>()
        {
            StatusCode = 200,
            Message = "Operation successful",
            Data = mapper.Map<ContactDto>(result)
        };

    }

    public Task<Domain.Models.Contact> UpdateAsync(Domain.Models.Contact entity)
    {
        throw new NotImplementedException();
    }
    
}