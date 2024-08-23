using CertExBackend.Data;
using CertExBackend.Interfaces;
using CertExBackend.Model;

namespace CertExBackend.Repository
{
    public class AwsAdminRepository : IAwsAdminRepository
    {
        private readonly ApiDbContext _dbContext;

        public AwsAdminRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<AwsAdmin> GetAllAwsAdmins()
        {
            return _dbContext.AwsAdmins.ToList();
        }

        public AwsAdmin GetAwsAdminById(int id)
        {
            return _dbContext.AwsAdmins.Find(id);
        }

        public void AddAwsAdmin(AwsAdmin awsAdmin)
        {
            _dbContext.AwsAdmins.Add(awsAdmin);
            _dbContext.SaveChanges();
        }

        public void UpdateAwsAdmin(AwsAdmin awsAdmin)
        {
            _dbContext.AwsAdmins.Update(awsAdmin);
            _dbContext.SaveChanges();
        }

        public void DeleteAwsAdmin(int id)
        {
            var awsAdmin = _dbContext.AwsAdmins.Find(id);
            if (awsAdmin != null)
            {
                _dbContext.AwsAdmins.Remove(awsAdmin);
                _dbContext.SaveChanges();
            }
        }
    }
}
