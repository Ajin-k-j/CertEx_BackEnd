using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;

namespace CertExBackend.Mappings
{
    public class PendingNominationProfile : Profile
    {
        public PendingNominationProfile()
        {
            CreateMap<Nomination, PendingNominationDto>()
                .ForMember(dest => dest.CertificationName, opt => opt.MapFrom(src => src.CertificationExam.CertificationName))
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee.FirstName + " " + src.Employee.LastName))
                .ForMember(dest => dest.ProviderName, opt => opt.MapFrom(src => src.CertificationExam.CertificationProvider.ProviderName))
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Employee.Department.DepartmentName));
        }
    }
}
