using CertExBackend.DTOs;

namespace CertExBackend.Services.IServices
{
    public interface IExamDetailService
    {
        Task<IEnumerable<ExamDetailDto>> GetAllExamDetailsAsync();
        Task<ExamDetailDto> GetExamDetailByIdAsync(int id);
        Task AddExamDetailAsync(ExamDetailDto examDetailDto);
        Task UpdateExamDetailAsync(ExamDetailDto examDetailDto);
        Task DeleteExamDetailAsync(int id);
    }
}
