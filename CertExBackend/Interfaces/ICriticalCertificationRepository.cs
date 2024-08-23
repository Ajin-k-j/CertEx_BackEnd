using CertExBackend.Model;

namespace CertExBackend.Interfaces
{
    public interface ICriticalCertificationRepository
    {
        IEnumerable<CriticalCertification> GetAllCriticalCertifications();
        CriticalCertification GetCriticalCertificationById(int id);
        void AddCriticalCertification(CriticalCertification criticalCertification);
        void UpdateCriticalCertification(CriticalCertification criticalCertification);
        void DeleteCriticalCertification(int id);
    }
}
