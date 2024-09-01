using AutoMapper;
using CertExBackend.Model;

public class EmployeeCertificationProfile : Profile
{
    public EmployeeCertificationProfile()
    {
        CreateMap<Nomination, EmployeeCertificationDto>()
             .ForMember(dest => dest.CertificationName, opt => opt.MapFrom(src => src.CertificationExam.CertificationName))
             .ForMember(dest => dest.ProviderName, opt => opt.MapFrom(src => src.CertificationExam.CertificationProvider.ProviderName))
             .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.CertificationExam.Level))
             .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.CertificationExam.CertificationTags.FirstOrDefault().CategoryTag.CategoryTagName))
             .ForMember(dest => dest.FromDate, opt => opt.MapFrom(src => src.ExamDetail.FirstOrDefault().MyCertification.FromDate))
             .ForMember(dest => dest.ExpiryDate, opt => opt.MapFrom(src => src.ExamDetail.FirstOrDefault().MyCertification.ExpiryDate))
             .ForMember(dest => dest.Url, opt => opt.MapFrom(src => src.ExamDetail.FirstOrDefault().MyCertification.Url));
    }
}
