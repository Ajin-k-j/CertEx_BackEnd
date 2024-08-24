using CertExBackend.Data;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CertExBackend.Repository
{
    public class CriticalCertificationRepository : ICriticalCertificationRepository
    {
        private readonly ApiDbContext _dbContext;

        public CriticalCertificationRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CriticalCertification>> GetAllCriticalCertificationsAsync()
        {
            return await _dbContext.CriticalCertifications.ToListAsync();
        }

        public async Task<CriticalCertification> GetCriticalCertificationByIdAsync(int id)
        {
            return await _dbContext.CriticalCertifications.FindAsync(id);
        }

        public async Task AddCriticalCertificationAsync(CriticalCertification criticalCertification)
        {
            _dbContext.CriticalCertifications.Add(criticalCertification);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCriticalCertificationAsync(CriticalCertification criticalCertification)
        {
            _dbContext.CriticalCertifications.Update(criticalCertification);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCriticalCertificationAsync(int id)
        {
            var criticalCertification = await _dbContext.CriticalCertifications.FindAsync(id);
            if (criticalCertification != null)
            {
                _dbContext.CriticalCertifications.Remove(criticalCertification);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
