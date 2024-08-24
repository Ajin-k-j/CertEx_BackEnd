using CertExBackend.Data;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CertExBackend.Repository
{
    public class MyCertificationRepository : IMyCertificationRepository
    {
        private readonly ApiDbContext _dbContext;

        public MyCertificationRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<MyCertification>> GetAllMyCertificationsAsync()
        {
            return await _dbContext.MyCertifications
                .Include(mc => mc.ExamDetails)
                .ToListAsync();
        }

        public async Task<MyCertification> GetMyCertificationByIdAsync(int id)
        {
            return await _dbContext.MyCertifications
                .Include(mc => mc.ExamDetails)
                .FirstOrDefaultAsync(mc => mc.Id == id);
        }

        public async Task AddMyCertificationAsync(MyCertification myCertification)
        {
            _dbContext.MyCertifications.Add(myCertification);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateMyCertificationAsync(MyCertification myCertification)
        {
            _dbContext.MyCertifications.Update(myCertification);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteMyCertificationAsync(int id)
        {
            var myCertification = await _dbContext.MyCertifications.FindAsync(id);
            if (myCertification != null)
            {
                _dbContext.MyCertifications.Remove(myCertification);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
