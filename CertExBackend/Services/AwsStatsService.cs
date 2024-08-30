using CertExBackend.DTOs;
using CertExBackend.Repositories;
using System.Threading.Tasks;

namespace CertExBackend.Services
{
    public class AwsStatsService : IAwsStatsService
    {
        private readonly IAwsStatsRepository _awsStatsRepository;

        public AwsStatsService(IAwsStatsRepository awsStatsRepository)
        {
            _awsStatsRepository = awsStatsRepository;
        }

        public async Task<AwsStatsDto> GetAwsStatsAsync()
        {
            var totalAwsNominations = await _awsStatsRepository.GetTotalAwsNominationsAsync();
            var pendingNominations = await _awsStatsRepository.GetPendingNominationsAsync();

            return new AwsStatsDto
            {
                TotalAwsNominations = totalAwsNominations,
                PendingNominations = pendingNominations
            };
        }
    }
}
