using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;

namespace CertExBackend.Mappings
{
    public class MyCertificationProfile : Profile
    {
        public MyCertificationProfile()
        {
            CreateMap<MyCertification, MyCertificationDto>();
            CreateMap<MyCertificationDto, MyCertification>();
        }
    }
}
