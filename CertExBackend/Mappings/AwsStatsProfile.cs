using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;

namespace CertExBackend.Mapping
{
    public class AwsStatsProfile : Profile
    {
        public AwsStatsProfile()
        {
            
            CreateMap<AwsStatsDto, AwsStatsDto>();
        }
    }
}
