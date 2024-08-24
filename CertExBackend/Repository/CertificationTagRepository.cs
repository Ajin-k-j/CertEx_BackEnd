using CertExBackend.Data;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CertExBackend.Repository
{
    public class CertificationTagRepository : ICertificationTagRepository
    {
        private readonly ApiDbContext _dbContext;

        public CertificationTagRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CertificationTag>> GetAllCertificationTagsAsync()
        {
            return await _dbContext.CertificationTags.ToListAsync();
        }

        public async Task<CertificationTag> GetCertificationTagByIdAsync(int id)
        {
            return await _dbContext.CertificationTags.FindAsync(id);
        }

        public async Task AddCertificationTagAsync(CertificationTag certificationTag)
        {
            _dbContext.CertificationTags.Add(certificationTag);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCertificationTagAsync(CertificationTag certificationTag)
        {
            _dbContext.CertificationTags.Update(certificationTag);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCertificationTagAsync(int id)
        {
            var certificationTag = await _dbContext.CertificationTags.FindAsync(id);
            if (certificationTag != null)
            {
                _dbContext.CertificationTags.Remove(certificationTag);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
