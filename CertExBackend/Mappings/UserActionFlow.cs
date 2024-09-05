using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;

namespace CertExBackend.Mappings
{
    public class UserActionFlow : Profile
    {
        public UserActionFlow()
        {
            CreateMap<CertificationExam, ActionFlowCertificationDto>()
                .ForMember(dest => dest.CertificationName, opt => opt.MapFrom(src => src.CertificationName))
                .ForMember(dest => dest.CertificationDescription, opt => opt.MapFrom(src => src.Description));

            CreateMap<CertificationProvider, ActionFlowProviderDto>()
                .ForMember(dest => dest.ProviderName, opt => opt.MapFrom(src => src.ProviderName))
                .ForMember(dest => dest.CertificationOfficialLink, opt => opt.MapFrom(src => src.CertificationExams.FirstOrDefault().OfficialLink));

            CreateMap<CertificationExam, ActionFlowNominationDto>()
                .ForMember(dest => dest.NominationOpenDate, opt => opt.MapFrom(src => src.NominationOpenDate))
                .ForMember(dest => dest.NominationCloseDate, opt => opt.MapFrom(src => src.NominationCloseDate));

            CreateMap<ActionFlowExamDetailDto, ExamDetail>()
          .ForMember(dest => dest.InvoiceUrl, opt => opt.MapFrom(src => src.Url));
        }
    }
}


