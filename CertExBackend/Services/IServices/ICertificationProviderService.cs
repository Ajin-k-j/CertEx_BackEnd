using CertExBackend.DTOs;

namespace CertExBackend.Services.IServices
{
    public interface ICertificationProviderService
    {
        Task<IEnumerable<CertificationProviderDto>> GetAllCertificationProvidersAsync();
        Task<CertificationProviderDto> GetCertificationProviderByIdAsync(int id);
        Task AddCertificationProviderAsync(CertificationProviderDto certificationProviderDto);
        Task UpdateCertificationProviderAsync(CertificationProviderDto certificationProviderDto);
        Task DeleteCertificationProviderAsync(int id);
    }
}
