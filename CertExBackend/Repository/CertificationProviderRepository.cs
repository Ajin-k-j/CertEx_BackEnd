using CertExBackend.Data;
using CertExBackend.Interfaces;
using CertExBackend.Model;

namespace CertExBackend.Repository
{
    public class CertificationProviderRepository : ICertificationProviderRepository
    {
        private readonly ApiDbContext _dbContext;

        public CertificationProviderRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CertificationProvider> GetAllCertificationProviders()
        {
            return _dbContext.CertificationProviders.ToList();
        }

        public CertificationProvider GetCertificationProviderById(int id)
        {
            return _dbContext.CertificationProviders.Find(id);
        }

        public void AddCertificationProvider(CertificationProvider provider)
        {
            _dbContext.CertificationProviders.Add(provider);
            _dbContext.SaveChanges();
        }

        public void UpdateCertificationProvider(CertificationProvider provider)
        {
            _dbContext.CertificationProviders.Update(provider);
            _dbContext.SaveChanges();
        }

        public void DeleteCertificationProvider(int id)
        {
            var provider = _dbContext.CertificationProviders.Find(id);
            if (provider != null)
            {
                _dbContext.CertificationProviders.Remove(provider);
                _dbContext.SaveChanges();
            }
        }
    }
}
