using CertExBackend.Model;

namespace CertExBackend.Repository.IRepository
{
    public interface IMyCertificationRepository
    {
        Task<IEnumerable<MyCertification>> GetAllMyCertificationsAsync();
        Task<MyCertification> GetMyCertificationByIdAsync(int id);
        Task AddMyCertificationAsync(MyCertification myCertification);
        Task UpdateMyCertificationAsync(MyCertification myCertification);
        Task DeleteMyCertificationAsync(int id);
    }
}
