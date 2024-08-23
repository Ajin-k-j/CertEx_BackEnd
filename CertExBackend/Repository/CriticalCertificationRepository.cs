using CertExBackend.Data;
using CertExBackend.Interfaces;
using CertExBackend.Model;

namespace CertExBackend.Repository
{
    public class CriticalCertificationRepository : ICriticalCertificationRepository
    {
        private readonly ApiDbContext _dbContext;

        public CriticalCertificationRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CriticalCertification> GetAllCriticalCertifications()
        {
            return _dbContext.CriticalCertifications.ToList();
        }

        public CriticalCertification GetCriticalCertificationById(int id)
        {
            return _dbContext.CriticalCertifications.Find(id);
        }

        public void AddCriticalCertification(CriticalCertification criticalCertification)
        {
            _dbContext.CriticalCertifications.Add(criticalCertification);
            _dbContext.SaveChanges();
        }

        public void UpdateCriticalCertification(CriticalCertification criticalCertification)
        {
            _dbContext.CriticalCertifications.Update(criticalCertification);
            _dbContext.SaveChanges();
        }

        public void DeleteCriticalCertification(int id)
        {
            var criticalCertification = _dbContext.CriticalCertifications.Find(id);
            if (criticalCertification != null)
            {
                _dbContext.CriticalCertifications.Remove(criticalCertification);
                _dbContext.SaveChanges();
            }
        }
    }
}
