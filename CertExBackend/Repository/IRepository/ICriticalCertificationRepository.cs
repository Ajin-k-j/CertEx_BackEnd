using CertExBackend.Model;

namespace CertExBackend.Repository.IRepository
{
    public interface ICriticalCertificationRepository
    {
        Task<IEnumerable<CriticalCertification>> GetAllCriticalCertificationsAsync();
        Task<CriticalCertification> GetCriticalCertificationByIdAsync(int id);
        Task AddCriticalCertificationAsync(CriticalCertification criticalCertification);
        Task UpdateCriticalCertificationAsync(CriticalCertification criticalCertification);
        Task DeleteCriticalCertificationAsync(int id);
    }
}
