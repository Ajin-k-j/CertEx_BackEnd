using CertExBackend.DTOs;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;

namespace CertExBackend.Services
{
    public class AwsBarGraphService : IAwsBarGraphService
    {

        private readonly IAwsBarGraphRepository _awsBarGraphRepository;

        public AwsBarGraphService(IAwsBarGraphRepository awsBarGraphRepository)
        {
            _awsBarGraphRepository = awsBarGraphRepository;
        }

        public async Task<IEnumerable<AwsBarGraphDto>> GetAwsBarGraphDataAsync()
        {
            return await _awsBarGraphRepository.GetAwsBarGraphDataAsync();
        }

        public async Task<MonthlyExamCompletionDTO> GetFilteredExamCompletionDataAsync(int financialYearId, int? departmentId)
        {
            return await _awsBarGraphRepository.GetFilteredExamCompletionDataAsync(financialYearId, departmentId);
        }
    }
}



