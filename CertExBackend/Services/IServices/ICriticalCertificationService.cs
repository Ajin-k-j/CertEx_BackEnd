using CertExBackend.DTOs;

namespace CertExBackend.Services.IServices
{
    public interface ICriticalCertificationService
    {
        Task<IEnumerable<CriticalCertificationDto>> GetAllCriticalCertificationsAsync();
        Task<CriticalCertificationDto> GetCriticalCertificationByIdAsync(int id);
        Task AddCriticalCertificationAsync(CriticalCertificationDto criticalCertificationDto);
        Task UpdateCriticalCertificationAsync(CriticalCertificationDto criticalCertificationDto);
        Task DeleteCriticalCertificationAsync(int id);
    }
}
