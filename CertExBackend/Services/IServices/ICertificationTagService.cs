using CertExBackend.DTOs;

namespace CertExBackend.Services.IServices
{
    public interface ICertificationTagService
    {
        Task<IEnumerable<CertificationTagDto>> GetAllCertificationTagsAsync();
        Task<CertificationTagDto> GetCertificationTagByIdAsync(int id);
        Task AddCertificationTagAsync(CertificationTagDto certificationTagDto);
        Task UpdateCertificationTagAsync(CertificationTagDto certificationTagDto);
        Task DeleteCertificationTagAsync(int id);
    }
}
