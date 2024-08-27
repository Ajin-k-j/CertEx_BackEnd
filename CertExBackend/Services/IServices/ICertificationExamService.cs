using CertExBackend.DTOs;
using CertExBackend.Model;

namespace CertExBackend.Services.IServices
{
    public interface ICertificationExamService
    {
        Task<IEnumerable<CertificationExamDto>> GetAllCertificationExamsAsync();
        Task<CertificationExamDto> GetCertificationExamByIdAsync(int id);
        Task AddCertificationExamAsync(CertificationExam certificationExam);
        Task UpdateCertificationExamAsync(CertificationExam certificationExam);
        Task DeleteCertificationExamAsync(int id);
    }
}
