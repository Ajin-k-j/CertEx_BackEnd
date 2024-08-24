using CertExBackend.DTOs;

namespace CertExBackend.Services.IServices
{
    public interface IMyCertificationService
    {
        Task<IEnumerable<MyCertificationDto>> GetAllMyCertificationsAsync();
        Task<MyCertificationDto> GetMyCertificationByIdAsync(int id);
        Task AddMyCertificationAsync(MyCertificationDto myCertificationDto);
        Task UpdateMyCertificationAsync(MyCertificationDto myCertificationDto);
        Task DeleteMyCertificationAsync(int id);
    }
}
