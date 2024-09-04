using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;

namespace CertExBackend.Mappings
{
    public class CertificationProviderProfile : Profile
    {
        public CertificationProviderProfile()
        {
            CreateMap<CertificationProvider, CertificationProviderDto>();
            CreateMap<CertificationProviderDto, CertificationProvider>();
        }
    }
}
