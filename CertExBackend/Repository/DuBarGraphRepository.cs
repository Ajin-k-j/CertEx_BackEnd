using CertExBackend.DTOs;

using CertExBackend.Data;
using CertExBackend.Repository.IRepository;
using CertExBackend.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CertExBackend.Repository
{
    public class DuBarGraphRepository : IDuBarGraphRepository
    {
        private readonly ApiDbContext _dbContext;

        public DuBarGraphRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DuBarGraphDto>> GetDuBarGraphDataAsync()
        {
            return await _dbContext.Nominations
                .Include(n => n.Employee)
                .ThenInclude(e => e.Department)
                .Include(n => n.CertificationExam)
                .ThenInclude(ce => ce.CertificationProvider)
                .Where(n => n.Employee.Department.DepartmentName == "DU1")
                .Select(n => new DuBarGraphDto
                {
                    ExamStatus = n.ExamStatus,
                    ExamDate = n.ExamDate,
                    DepartmentName = "DU1",
                    ProviderName = n.CertificationExam.CertificationProvider.ProviderName
                })
                .ToListAsync();
        }

        public async Task<MonthlyExamCompletionDTO> GetFilteredExamCompletionDataAsync(int financialYearId, int? providerId)
        {
            var query = _dbContext.Nominations
                .Include(n => n.Employee)
                .ThenInclude(e => e.Department)
                .Include(n => n.CertificationExam)
                .ThenInclude(ce => ce.CertificationProvider)
                .Where(n => n.ExamStatus == "Completed" && n.Employee.Department.DepartmentName == "DU1");

            if (providerId.HasValue)
            {
                query = query.Where(n => n.CertificationExam.ProviderId == providerId.Value);
            }

            if (financialYearId > 0)
            {
                var financialYear = await _dbContext.FinancialYears.FindAsync(financialYearId);
                if (financialYear != null)
                {
                    query = query.Where(n => n.ExamDate >= financialYear.FromDate && n.ExamDate <= financialYear.ToDate);
                }
            }

            var result = new MonthlyExamCompletionDTO
            {
                April = query.Count(n => n.ExamDate.Value.Month == 4),
                May = query.Count(n => n.ExamDate.Value.Month == 5),
                June = query.Count(n => n.ExamDate.Value.Month == 6),
                July = query.Count(n => n.ExamDate.Value.Month == 7),
                August = query.Count(n => n.ExamDate.Value.Month == 8),
                September = query.Count(n => n.ExamDate.Value.Month == 9),
                October = query.Count(n => n.ExamDate.Value.Month == 10),
                November = query.Count(n => n.ExamDate.Value.Month == 11),
                December = query.Count(n => n.ExamDate.Value.Month == 12),
                January = query.Count(n => n.ExamDate.Value.Month == 1),
                February = query.Count(n => n.ExamDate.Value.Month == 2),
                March = query.Count(n => n.ExamDate.Value.Month == 3),
            };

            return result;
        }
    }
}
