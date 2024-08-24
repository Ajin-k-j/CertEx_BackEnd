using CertExBackend.DTOs;

namespace CertExBackend.Services.IServices
{
    public interface ICertificationExamService
    {
        Task<IEnumerable<CertificationExamDto>> GetAllCertificationExamsAsync();
        Task<CertificationExamDto> GetCertificationExamByIdAsync(int id);
        Task AddCertificationExamAsync(CertificationExamDto certificationExamDto);
        Task UpdateCertificationExamAsync(CertificationExamDto certificationExamDto);
        Task DeleteCertificationExamAsync(int id);
    }
}
