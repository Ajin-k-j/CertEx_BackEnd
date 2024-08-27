using CertExBackend.DTOs;
namespace CertExBackend.Repository.IRepository
{
    public interface IDuBarGraphRepository
    {
        Task<IEnumerable<DuBarGraphDto>> GetDuBarGraphDataAsync();
        Task<MonthlyExamCompletionDTO> GetFilteredExamCompletionDataAsync(int financialYearId, int? providerId);

    }
}
