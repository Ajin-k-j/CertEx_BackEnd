using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;

namespace CertExBackend.Mappings
{
    public class NominationProfile : Profile
    {
        public NominationProfile()
        {
            CreateMap<Nomination, NominationDto>();
            CreateMap<NominationDto, Nomination>();
            CreateMap<NominationCreateDto, Nomination>();
        }
    }
}
