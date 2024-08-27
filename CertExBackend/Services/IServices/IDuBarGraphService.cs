using CertExBackend.DTOs;

namespace CertExBackend.Services.IServices
{
    public interface IDuBarGraphService
    {
        Task<IEnumerable<DuBarGraphDto>> GetDuBarGraphDataAsync();
        Task<MonthlyExamCompletionDTO> GetFilteredExamCompletionDataAsync(int financialYearId, int? providerId);

    }
}
