using System.Threading.Tasks;

namespace CertExBackend.Repositories
{
    public interface IAwsStatsRepository
    {
        Task<int> GetTotalAwsNominationsAsync();
        Task<int> GetPendingNominationsAsync();
    }
}
