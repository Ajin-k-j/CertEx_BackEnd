using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;

namespace CertExBackend.Mappings
{
    public class ExamDetailProfile : Profile
    {
        public ExamDetailProfile()
        {
            CreateMap<ExamDetail, ExamDetailDto>();
            CreateMap<ExamDetailDto, ExamDetail>();
        }
    }
}
