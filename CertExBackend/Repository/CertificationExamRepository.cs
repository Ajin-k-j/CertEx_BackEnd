using CertExBackend.Data;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CertExBackend.Repository
{
    public class CertificationExamRepository : ICertificationExamRepository
    {
        private readonly ApiDbContext _dbContext;

        public CertificationExamRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CertificationExam>> GetAllCertificationExamsAsync()
        {
            return await _dbContext.CertificationExams
                .Include(e => e.CertificationTags)
                .ThenInclude(ct => ct.CategoryTag) // Assuming CategoryTag is a related entity
                .Include(e => e.CertificationProvider) // Include the CertificationProvider
                .ToListAsync();
        }

        public async Task<CertificationExam> GetCertificationExamByIdAsync(int id)
        {
            return await _dbContext.CertificationExams
                .Include(e => e.CertificationTags) // Eager loading
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddCertificationExamAsync(CertificationExam certificationExam)
        {
            _dbContext.CertificationExams.Add(certificationExam);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCertificationExamAsync(CertificationExam certificationExam)
        {
            _dbContext.CertificationExams.Update(certificationExam);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCertificationExamAsync(int id)
        {
            var certificationExam = await _dbContext.CertificationExams.FindAsync(id);
            if (certificationExam != null)
            {
                _dbContext.CertificationExams.Remove(certificationExam);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
