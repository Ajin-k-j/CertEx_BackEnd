using CertExBackend.DTOs;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;

namespace CertExBackend.Services
{
    public class LndBarGraphService : ILndBarGraphService
    {
        private readonly ILndBarGraphRepository _repository;

        public LndBarGraphService(ILndBarGraphRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LndBarGraphDTO>> GetLndBarGraphDataAsync()
        {
            return await _repository.GetLndBarGraphDataAsync();
        }
        public async Task<MonthlyExamCompletionDTO> GetFilteredExamCompletionDataAsync(int financialYearId, int? departmentId, int? providerId)
        {
            return await _repository.GetFilteredExamCompletionDataAsync(financialYearId, departmentId, providerId);
        }
    }
}