using CertExBackend.Model;

namespace CertExBackend.Interfaces
{
    public interface IAwsAdminRepository
    {
        IEnumerable<AwsAdmin> GetAllAwsAdmins();
        AwsAdmin GetAwsAdminById(int id);
        void AddAwsAdmin(AwsAdmin awsAdmin);
        void UpdateAwsAdmin(AwsAdmin awsAdmin);
        void DeleteAwsAdmin(int id);
    }
}
