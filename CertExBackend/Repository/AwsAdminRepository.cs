using CertExBackend.Data;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CertExBackend.Repository
{
    public class AwsAdminRepository : IAwsAdminRepository
    {
        private readonly ApiDbContext _dbContext;

        public AwsAdminRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<AwsAdmin>> GetAllAwsAdminsAsync()
        {
            return await _dbContext.AwsAdmins.ToListAsync();
        }

        public async Task<AwsAdmin> GetAwsAdminByIdAsync(int id)
        {
            return await _dbContext.AwsAdmins.FindAsync(id);
        }

        public async Task AddAwsAdminAsync(AwsAdmin awsAdmin)
        {
            _dbContext.AwsAdmins.Add(awsAdmin);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAwsAdminAsync(AwsAdmin awsAdmin)
        {
            _dbContext.AwsAdmins.Update(awsAdmin);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAwsAdminAsync(int id)
        {
            var awsAdmin = await _dbContext.AwsAdmins.FindAsync(id);
            if (awsAdmin != null)
            {
                _dbContext.AwsAdmins.Remove(awsAdmin);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
