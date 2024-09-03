using AutoMapper;
using CertExBackend.DTO;
using CertExBackend.Model;

namespace CertExBackend.Mapping
{
    public class AwsNominationProfile : Profile
    {
        public AwsNominationProfile()
        {
            CreateMap<Nomination, AwsNominationDto>()
                .ForMember(dest => dest.NominationId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => $"{src.Employee.FirstName} {src.Employee.LastName}"))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Employee.Email))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Employee.Department.DepartmentName)) 
                .ForMember(dest => dest.CertificationName, opt => opt.MapFrom(src => src.CertificationExam.CertificationName))
                .ForMember(dest => dest.Provider, opt => opt.MapFrom(src => src.CertificationExam.CertificationProvider.ProviderName))
                .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.CertificationExam.Level))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.ExamDate.HasValue ? src.ExamDate.Value : DateTime.MinValue))
                .ForMember(dest => dest.Criticality, opt => opt.Ignore()); // We'll set this in the service layer
        }
    }
}
