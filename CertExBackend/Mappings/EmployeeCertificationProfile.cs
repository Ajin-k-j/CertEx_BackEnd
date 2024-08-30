using AutoMapper;
using CertExBackend.Model;
using CertExBackend.DTOs;

public class EmployeeCertificationProfile : Profile
{
    public EmployeeCertificationProfile()
    {
        CreateMap<ExamDetail, EmployeeCertificationDto>()
            .ForMember(dest => dest.CertificationId, opt => opt.MapFrom(src => src.MyCertification.Id))
            .ForMember(dest => dest.CertificationName, opt => opt.MapFrom(src => src.MyCertification.Filename))
            .ForMember(dest => dest.ProviderName, opt => opt.MapFrom(src => src.MyCertification.Url))  // Assuming provider name can be fetched or defined as per available data
            .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.MyCertification.FromDate))  // Assuming level can be fetched or defined as per available data
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.MyCertification.ExpiryDate))  // Assuming category can be fetched or defined as per available data
            .ForMember(dest => dest.FromDate, opt => opt.MapFrom(src => src.MyCertification.FromDate))
            .ForMember(dest => dest.ExpiryDate, opt => opt.MapFrom(src => src.MyCertification.ExpiryDate));
    }
}
