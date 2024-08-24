using AutoMapper;
using medipro_patient_service.Application.Contact.Dtos;
using medipro_patient_service.Application.Patient.Dtos;

namespace medipro_patient_service.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ContactDto, Domain.Models.Contact>().ReverseMap();
        CreateMap<PatientDto, Domain.Models.Patient>().ReverseMap();
    }
}