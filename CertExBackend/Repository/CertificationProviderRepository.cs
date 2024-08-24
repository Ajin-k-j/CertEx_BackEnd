using CertExBackend.Data;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CertExBackend.Repository
{
    public class CertificationProviderRepository : ICertificationProviderRepository
    {
        private readonly ApiDbContext _dbContext;

        public CertificationProviderRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CertificationProvider>> GetAllCertificationProvidersAsync()
        {
            return await _dbContext.CertificationProviders.ToListAsync();
        }

        public async Task<CertificationProvider> GetCertificationProviderByIdAsync(int id)
        {
            return await _dbContext.CertificationProviders.FindAsync(id);
        }

        public async Task AddCertificationProviderAsync(CertificationProvider certificationProvider)
        {
            _dbContext.CertificationProviders.Add(certificationProvider);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCertificationProviderAsync(CertificationProvider certificationProvider)
        {
            _dbContext.CertificationProviders.Update(certificationProvider);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCertificationProviderAsync(int id)
        {
            var certificationProvider = await _dbContext.CertificationProviders.FindAsync(id);
            if (certificationProvider != null)
            {
                _dbContext.CertificationProviders.Remove(certificationProvider);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
