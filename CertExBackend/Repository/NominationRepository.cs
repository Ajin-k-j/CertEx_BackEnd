using CertExBackend.Data;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CertExBackend.Repository
{
    public class NominationRepository : INominationRepository
    {
        private readonly ApiDbContext _dbContext;

        public NominationRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Nomination>> GetAllNominationsAsync()
        {
            return await _dbContext.Nominations
                .Include(n => n.CertificationExam)
                .Include(n => n.Employee)
                .Include(n => n.ExamDetail)
                .ToListAsync();
        }

        public async Task<Nomination> GetNominationByIdAsync(int id)
        {
            return await _dbContext.Nominations
                .Include(n => n.CertificationExam)
                .Include(n => n.Employee)
                .Include(n => n.ExamDetail)
                .FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task AddNominationAsync(Nomination nomination)
        {
            _dbContext.Nominations.Add(nomination);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateNominationAsync(Nomination nomination)
        {
            _dbContext.Nominations.Update(nomination);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteNominationAsync(int id)
        {
            var nomination = await _dbContext.Nominations.FindAsync(id);
            if (nomination != null)
            {
                _dbContext.Nominations.Remove(nomination);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
