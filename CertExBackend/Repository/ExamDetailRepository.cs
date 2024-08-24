using CertExBackend.Data;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CertExBackend.Repository
{
    public class ExamDetailRepository : IExamDetailRepository
    {
        private readonly ApiDbContext _dbContext;

        public ExamDetailRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ExamDetail>> GetAllExamDetailsAsync()
        {
            return await _dbContext.ExamDetails
                .Include(ed => ed.Nomination)
                .Include(ed => ed.MyCertification)
                .ToListAsync();
        }

        public async Task<ExamDetail> GetExamDetailByIdAsync(int id)
        {
            return await _dbContext.ExamDetails
                .Include(ed => ed.Nomination)
                .Include(ed => ed.MyCertification)
                .FirstOrDefaultAsync(ed => ed.Id == id);
        }

        public async Task AddExamDetailAsync(ExamDetail examDetail)
        {
            _dbContext.ExamDetails.Add(examDetail);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateExamDetailAsync(ExamDetail examDetail)
        {
            _dbContext.ExamDetails.Update(examDetail);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteExamDetailAsync(int id)
        {
            var examDetail = await _dbContext.ExamDetails.FindAsync(id);
            if (examDetail != null)
            {
                _dbContext.ExamDetails.Remove(examDetail);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
