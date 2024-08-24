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
        }
    }
}
