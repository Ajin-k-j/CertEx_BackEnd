using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CertExBackend.Mappings
{
    public class AwsAdminProfile : Profile
    {
        public AwsAdminProfile()
        {
            CreateMap<AwsAdmin, AwsAdminDto>().ReverseMap();
        }
    }
}
