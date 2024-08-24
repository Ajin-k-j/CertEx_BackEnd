using CertExBackend.DTOs;

namespace CertExBackend.Services.IServices
{
    public interface IFinancialYearService
    {
        Task<IEnumerable<FinancialYearDto>> GetAllFinancialYearsAsync();
        Task<FinancialYearDto> GetFinancialYearByIdAsync(int id);
        Task AddFinancialYearAsync(FinancialYearDto financialYearDto);
        Task UpdateFinancialYearAsync(FinancialYearDto financialYearDto);
        Task DeleteFinancialYearAsync(int id);
    }
}
