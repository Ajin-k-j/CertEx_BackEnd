using CertExBackend.Data;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CertExBackend.Repository
{
    public class FinancialYearRepository : IFinancialYearRepository
    {
        private readonly ApiDbContext _dbContext;

        public FinancialYearRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<FinancialYear>> GetAllFinancialYearsAsync()
        {
            return await _dbContext.FinancialYears
                .Include(fy => fy.CriticalCertifications)
                .ToListAsync();
        }

        public async Task<FinancialYear> GetFinancialYearByIdAsync(int id)
        {
            return await _dbContext.FinancialYears
                .Include(fy => fy.CriticalCertifications)
                .FirstOrDefaultAsync(fy => fy.Id == id);
        }

        public async Task AddFinancialYearAsync(FinancialYear financialYear)
        {
            _dbContext.FinancialYears.Add(financialYear);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateFinancialYearAsync(FinancialYear financialYear)
        {
            _dbContext.FinancialYears.Update(financialYear);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteFinancialYearAsync(int id)
        {
            var financialYear = await _dbContext.FinancialYears.FindAsync(id);
            if (financialYear != null)
            {
                _dbContext.FinancialYears.Remove(financialYear);
                await _dbContext.SaveChangesAsync();
            }
        }
        public async Task<FinancialYear> GetFinancialYearForDateAsync(DateTime date)
        {
            return await _dbContext.FinancialYears
                .Where(fy => fy.FromDate <= date && fy.ToDate >= date)
                .FirstOrDefaultAsync();
        }
    }
}
