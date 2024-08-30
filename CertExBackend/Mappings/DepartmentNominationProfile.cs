using AutoMapper;
using CertExBackend.Model;

public class DepartmentNominationProfile : Profile
{
    public DepartmentNominationProfile()
    {
        CreateMap<Nomination, DepartmentNominationDto>()
            .ForMember(dest => dest.NominationId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => $"{src.Employee.FirstName} {src.Employee.LastName}"))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Employee.Email))
            .ForMember(dest => dest.Provider, opt => opt.MapFrom(src => src.CertificationExam.CertificationProvider.ProviderName))
            .ForMember(dest => dest.CertificationName, opt => opt.MapFrom(src => src.CertificationExam.CertificationName))
            .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.CertificationExam.Level))
            .ForMember(dest => dest.PlannedMonthOfExam, opt => opt.MapFrom(src => src.PlannedExamMonth))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.NominationStatus))
            .ForMember(dest => dest.MotivationDescription, opt => opt.MapFrom(src => src.MotivationDescription));
        
    }
}
