using AutoMapper;
using medipro_patient_service.Application.DTO;
using medipro_patient_service.Domain.Models;

namespace medipro_patient_service.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ContactDto, Contact>().ReverseMap();
        CreateMap<PatientDto, Domain.Models.Patient>().ReverseMap();
        CreateMap<MedicalHistoryDto, MedicalHistory>().ReverseMap();
        CreateMap<PresentIllnessDto, PresentIllness>().ReverseMap();
        CreateMap<MedicationDto, Medication>().ReverseMap();
        CreateMap<AllergyDto, Allergy>().ReverseMap();
        CreateMap<FamilyConditionDto, FamilyCondition>().ReverseMap();
        CreateMap<ImmunizationDto, Immunization>().ReverseMap();
        CreateMap<SubstanceUseDto, SubstanceUse>().ReverseMap();
        CreateMap<SexualHistoryDto, SexualHistory>().ReverseMap();
        CreateMap<ScreeningDto, Screening>().ReverseMap();
        CreateMap<VaccinationDto, Vaccination>().ReverseMap();
        CreateMap<ReviewOfSystemDto, ReviewOfSystem>().ReverseMap();
        CreateMap<PastMedicalHistoryDto, PastMedicalHistory>().ReverseMap();
        CreateMap<IllnessDto, Illness>().ReverseMap();
        CreateMap<ChronicConditionDto, ChronicCondition>().ReverseMap();
        CreateMap<SurgeryDto, Surgery>().ReverseMap();
        CreateMap<InjuryDto, Injury>().ReverseMap();
        
    }
}