using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;

namespace CertExBackend.Mappings
{
    public class CertificationExamProfile : Profile
    {
        public CertificationExamProfile()
        {
            CreateMap<CertificationExam, CertificationExamDto>();
        }
    }
}
