using CertExBackend.Data;
using CertExBackend.Interfaces;
using CertExBackend.Model;

namespace CertExBackend.Repository
{
    public class CertificationTagRepository : ICertificationTagRepository
    {
        private readonly ApiDbContext _dbContext;

        public CertificationTagRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CertificationTag> GetAllCertificationTags()
        {
            return _dbContext.CertificationTags.ToList();
        }

        public CertificationTag GetCertificationTagById(int id)
        {
            return _dbContext.CertificationTags.Find(id);
        }

        public void AddCertificationTag(CertificationTag tag)
        {
            _dbContext.CertificationTags.Add(tag);
            _dbContext.SaveChanges();
        }

        public void UpdateCertificationTag(CertificationTag tag)
        {
            _dbContext.CertificationTags.Update(tag);
            _dbContext.SaveChanges();
        }

        public void DeleteCertificationTag(int id)
        {
            var tag = _dbContext.CertificationTags.Find(id);
            if (tag != null)
            {
                _dbContext.CertificationTags.Remove(tag);
                _dbContext.SaveChanges();
            }
        }
    }
}
