using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;

namespace CertExBackend.Services
{
    public class FinancialYearService : IFinancialYearService
    {
        private readonly IFinancialYearRepository _financialYearRepository;
        private readonly IMapper _mapper;

        public FinancialYearService(
            IFinancialYearRepository financialYearRepository,
            IMapper mapper)
        {
            _financialYearRepository = financialYearRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FinancialYearDto>> GetAllFinancialYearsAsync()
        {
            var financialYears = await _financialYearRepository.GetAllFinancialYearsAsync();
            return _mapper.Map<IEnumerable<FinancialYearDto>>(financialYears);
        }

        public async Task<FinancialYearDto> GetFinancialYearByIdAsync(int id)
        {
            var financialYear = await _financialYearRepository.GetFinancialYearByIdAsync(id);
            return _mapper.Map<FinancialYearDto>(financialYear);
        }

        public async Task AddFinancialYearAsync(FinancialYearDto financialYearDto)
        {
            var financialYear = _mapper.Map<FinancialYear>(financialYearDto);
            await _financialYearRepository.AddFinancialYearAsync(financialYear);
        }

        public async Task UpdateFinancialYearAsync(FinancialYearDto financialYearDto)
        {
            var financialYear = _mapper.Map<FinancialYear>(financialYearDto);
            await _financialYearRepository.UpdateFinancialYearAsync(financialYear);
        }

        public async Task DeleteFinancialYearAsync(int id)
        {
            await _financialYearRepository.DeleteFinancialYearAsync(id);
        }
    }
}
