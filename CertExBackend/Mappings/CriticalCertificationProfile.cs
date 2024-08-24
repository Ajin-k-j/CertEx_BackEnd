using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;

namespace CertExBackend.Mappings
{
    public class CriticalCertificationProfile : Profile
    {
        public CriticalCertificationProfile()
        {
            CreateMap<CriticalCertification, CriticalCertificationDto>();
            CreateMap<CriticalCertificationDto, CriticalCertification>();
        }
    }
}
