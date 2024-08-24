using CertExBackend.Model;

namespace CertExBackend.Repository.IRepository
{
    public interface IExamDetailRepository
    {
        Task<IEnumerable<ExamDetail>> GetAllExamDetailsAsync();
        Task<ExamDetail> GetExamDetailByIdAsync(int id);
        Task AddExamDetailAsync(ExamDetail examDetail);
        Task UpdateExamDetailAsync(ExamDetail examDetail);
        Task DeleteExamDetailAsync(int id);
    }
}
