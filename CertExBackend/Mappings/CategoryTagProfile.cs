using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;

namespace CertExBackend.Mappings
{
    public class CategoryTagProfile : Profile
    {
        public CategoryTagProfile()
        {
            CreateMap<CategoryTag, CategoryTagDto>();
        }
    }
}
