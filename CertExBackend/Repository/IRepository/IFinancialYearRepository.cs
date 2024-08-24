using CertExBackend.Model;

namespace CertExBackend.Repository.IRepository
{
    public interface IFinancialYearRepository
    {
        Task<IEnumerable<FinancialYear>> GetAllFinancialYearsAsync();
        Task<FinancialYear> GetFinancialYearByIdAsync(int id);
        Task AddFinancialYearAsync(FinancialYear financialYear);
        Task UpdateFinancialYearAsync(FinancialYear financialYear);
        Task DeleteFinancialYearAsync(int id);
    }
}
