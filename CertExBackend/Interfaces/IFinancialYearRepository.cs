using CertExBackend.Model;

namespace CertExBackend.Interfaces
{
    public interface IFinancialYearRepository
    {
        IEnumerable<FinancialYear> GetAllFinancialYears();
        FinancialYear GetFinancialYearById(int id);
        void AddFinancialYear(FinancialYear financialYear);
        void UpdateFinancialYear(FinancialYear financialYear);
        void DeleteFinancialYear(int id);
    }
}
