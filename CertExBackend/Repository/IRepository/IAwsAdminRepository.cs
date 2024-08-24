using CertExBackend.Model;

namespace CertExBackend.Repository.IRepository
{
    public interface IAwsAdminRepository
    {
        Task<IEnumerable<AwsAdmin>> GetAllAwsAdminsAsync();
        Task<AwsAdmin> GetAwsAdminByIdAsync(int id);
        Task AddAwsAdminAsync(AwsAdmin awsAdmin);
        Task UpdateAwsAdminAsync(AwsAdmin awsAdmin);
        Task DeleteAwsAdminAsync(int id);
    }
}
