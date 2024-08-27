using CertExBackend.DTOs;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;

namespace CertExBackend.Services
{
    public class DuBarGraphService : IDuBarGraphService
    {
        private readonly IDuBarGraphRepository _duBarGraphRepository;

        public DuBarGraphService(IDuBarGraphRepository duBarGraphRepository)
        {
            _duBarGraphRepository = duBarGraphRepository;
        }

        public async Task<IEnumerable<DuBarGraphDto>> GetDuBarGraphDataAsync()
        {
            return await _duBarGraphRepository.GetDuBarGraphDataAsync();
        }

        public async Task<MonthlyExamCompletionDTO> GetFilteredExamCompletionDataAsync(int financialYearId, int? providerId)
        {
            return await _duBarGraphRepository.GetFilteredExamCompletionDataAsync(financialYearId, providerId);
        }
    }
}

