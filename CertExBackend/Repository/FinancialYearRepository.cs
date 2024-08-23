using CertExBackend.Data;
using CertExBackend.Interfaces;
using CertExBackend.Model;

namespace CertExBackend.Repository
{
    public class FinancialYearRepository : IFinancialYearRepository
    {
        private readonly ApiDbContext _dbContext;

        public FinancialYearRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<FinancialYear> GetAllFinancialYears()
        {
            return _dbContext.FinancialYears.ToList();
        }

        public FinancialYear GetFinancialYearById(int id)
        {
            return _dbContext.FinancialYears.Find(id);
        }

        public void AddFinancialYear(FinancialYear financialYear)
        {
            _dbContext.FinancialYears.Add(financialYear);
            _dbContext.SaveChanges();
        }

        public void UpdateFinancialYear(FinancialYear financialYear)
        {
            _dbContext.FinancialYears.Update(financialYear);
            _dbContext.SaveChanges();
        }

        public void DeleteFinancialYear(int id)
        {
            var financialYear = _dbContext.FinancialYears.Find(id);
            if (financialYear != null)
            {
                _dbContext.FinancialYears.Remove(financialYear);
                _dbContext.SaveChanges();
            }
        }
    }
}
