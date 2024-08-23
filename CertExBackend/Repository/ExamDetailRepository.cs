using CertExBackend.Data;
using CertExBackend.Interfaces;
using CertExBackend.Model;

namespace CertExBackend.Repository
{
    public class ExamDetailRepository : IExamDetailRepository
    {
        private readonly ApiDbContext _dbContext;

        public ExamDetailRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<ExamDetail> GetAllExamDetails()
        {
            return _dbContext.ExamDetails.ToList();
        }

        public ExamDetail GetExamDetailById(int id)
        {
            return _dbContext.ExamDetails.Find(id);
        }

        public void AddExamDetail(ExamDetail examDetail)
        {
            _dbContext.ExamDetails.Add(examDetail);
            _dbContext.SaveChanges();
        }

        public void UpdateExamDetail(ExamDetail examDetail)
        {
            _dbContext.ExamDetails.Update(examDetail);
            _dbContext.SaveChanges();
        }

        public void DeleteExamDetail(int id)
        {
            var examDetail = _dbContext.ExamDetails.Find(id);
            if (examDetail != null)
            {
                _dbContext.ExamDetails.Remove(examDetail);
                _dbContext.SaveChanges();
            }
        }
    }
}
