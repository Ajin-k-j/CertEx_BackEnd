using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;

namespace CertExBackend.Mappings
{
    public class CertificationTagProfile : Profile
    {
        public CertificationTagProfile()
        {
            CreateMap<CertificationTag, CertificationTagDto>();
            // Map from CertificationTagDto to CertificationTag
            CreateMap<CertificationTagDto, CertificationTag>();
        }
    }
}
