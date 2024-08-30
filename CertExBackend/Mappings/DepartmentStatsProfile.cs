using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;

namespace CertExBackend.Mapping
{
    public class DepartmentStatsProfile : Profile
    {
        public DepartmentStatsProfile()
        {
            CreateMap<Department, DepartmentStatsDto>()
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.DepartmentName))
                .ForMember(dest => dest.Employees, opt => opt.MapFrom(src => src.Employees.Count))
                .ForMember(dest => dest.Certifications, opt => opt.Ignore()); // Will be calculated separately
        }
    }
}
