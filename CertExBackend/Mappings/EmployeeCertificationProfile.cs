using AutoMapper;
using CertExBackend.Model;

public class EmployeeCertificationProfile : Profile
{
    public EmployeeCertificationProfile()
    {
        CreateMap<Nomination, EmployeeCertificationDto>()
            .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
            .ForMember(dest => dest.CertificationId, opt => opt.MapFrom(src => src.CertificationId))
            .ForMember(dest => dest.CertificationName, opt => opt.MapFrom(src => src.CertificationExam.CertificationName))
            .ForMember(dest => dest.ProviderName, opt => opt.MapFrom(src => src.CertificationExam.CertificationProvider.ProviderName))
            .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.CertificationExam.Level))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.CertificationExam.CertificationTag.FirstOrDefault().CategoryTag.CategoryTagName))
            .ForMember(dest => dest.FromDate, opt => opt.MapFrom(src => src.ExamDetails.MyCertification.FromDate))
            .ForMember(dest => dest.ExpiryDate, opt => opt.MapFrom(src => src.ExamDetails.MyCertification.ExpiryDate))
            .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.ExamDetails.MyCertification.Url));


    }
}

