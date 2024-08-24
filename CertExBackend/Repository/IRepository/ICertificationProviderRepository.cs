using CertExBackend.Model;

namespace CertExBackend.Repository.IRepository
{
    public interface ICertificationProviderRepository
    {
        Task<IEnumerable<CertificationProvider>> GetAllCertificationProvidersAsync();
        Task<CertificationProvider> GetCertificationProviderByIdAsync(int id);
        Task AddCertificationProviderAsync(CertificationProvider certificationProvider);
        Task UpdateCertificationProviderAsync(CertificationProvider certificationProvider);
        Task DeleteCertificationProviderAsync(int id);
    }
}
