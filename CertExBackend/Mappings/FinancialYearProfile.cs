using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;

namespace CertExBackend.Mappings
{
    public class FinancialYearProfile : Profile
    {
        public FinancialYearProfile()
        {
            CreateMap<FinancialYear, FinancialYearDto>();
            CreateMap<FinancialYearDto, FinancialYear>();
        }
    }
}
