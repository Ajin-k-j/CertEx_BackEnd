using CertExBackend.Model;

namespace CertExBackend.Repository.IRepository
{
    public interface IFinancialYearRepository
    {
        Task<FinancialYear> GetFinancialYearForDateAsync(DateTime date);
        Task<IEnumerable<FinancialYear>> GetAllFinancialYearsAsync();
        Task<FinancialYear> GetFinancialYearByIdAsync(int id);
        Task AddFinancialYearAsync(FinancialYear financialYear);
        Task UpdateFinancialYearAsync(FinancialYear financialYear);
        Task DeleteFinancialYearAsync(int id);
    }
}
