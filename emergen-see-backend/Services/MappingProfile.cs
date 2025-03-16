using AutoMapper;
using emergen_see_backend.DTOs;
using emergen_see_backend.Models;

namespace emergen_see_backend.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatientDto>().ReverseMap();
            CreateMap<Queue, QueueDto>().ReverseMap();
            CreateMap<Doctor, DoctorDto>().ReverseMap();
            CreateMap<TriageForm, TriageFormDto>().ReverseMap();
        }
    }
}
