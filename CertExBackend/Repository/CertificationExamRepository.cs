using CertExBackend.Data;
using CertExBackend.Interfaces;
using CertExBackend.Model;

namespace CertExBackend.Repository
{
    public class CertificationExamRepository : ICertificationExamRepository
    {
        private readonly ApiDbContext _dbContext;

        public CertificationExamRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<CertificationExam> GetAllCertificationExams()
        {
            return _dbContext.CertificationExams.ToList();
        }

        public CertificationExam GetCertificationExamById(int id)
        {
            return _dbContext.CertificationExams.Find(id);
        }

        public void AddCertificationExam(CertificationExam exam)
        {
            _dbContext.CertificationExams.Add(exam);
            _dbContext.SaveChanges();
        }

        public void UpdateCertificationExam(CertificationExam exam)
        {
            _dbContext.CertificationExams.Update(exam);
            _dbContext.SaveChanges();
        }

        public void DeleteCertificationExam(int id)
        {
            var exam = _dbContext.CertificationExams.Find(id);
            if (exam != null)
            {
                _dbContext.CertificationExams.Remove(exam);
                _dbContext.SaveChanges();
            }
        }
    }
}
