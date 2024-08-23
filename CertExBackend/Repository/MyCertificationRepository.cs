using CertExBackend.Data;
using CertExBackend.Interfaces;
using CertExBackend.Model;

namespace CertExBackend.Repository
{
    public class MyCertificationRepository : IMyCertificationRepository
    {
        private readonly ApiDbContext _dbContext;

        public MyCertificationRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<MyCertification> GetAllMyCertifications()
        {
            return _dbContext.MyCertifications.ToList();
        }

        public MyCertification GetMyCertificationById(int id)
        {
            return _dbContext.MyCertifications.Find(id);
        }

        public void AddMyCertification(MyCertification certification)
        {
            _dbContext.MyCertifications.Add(certification);
            _dbContext.SaveChanges();
        }

        public void UpdateMyCertification(MyCertification certification)
        {
            _dbContext.MyCertifications.Update(certification);
            _dbContext.SaveChanges();
        }

        public void DeleteMyCertification(int id)
        {
            var certification = _dbContext.MyCertifications.Find(id);
            if (certification != null)
            {
                _dbContext.MyCertifications.Remove(certification);
                _dbContext.SaveChanges();
            }
        }
    }
}
