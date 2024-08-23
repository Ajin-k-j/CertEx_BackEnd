using CertExBackend.Model;

namespace CertExBackend.Interfaces
{
    public interface ICertificationProviderRepository
    {
        IEnumerable<CertificationProvider> GetAllCertificationProviders();
        CertificationProvider GetCertificationProviderById(int id);
        void AddCertificationProvider(CertificationProvider provider);
        void UpdateCertificationProvider(CertificationProvider provider);
        void DeleteCertificationProvider(int id);
    }
}
