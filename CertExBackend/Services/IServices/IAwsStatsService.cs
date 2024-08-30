// Services/IAwsStatsService.cs
using CertExBackend.DTOs;
using System.Threading.Tasks;

namespace CertExBackend.Services
{
    public interface IAwsStatsService
    {
        Task<AwsStatsDto> GetAwsStatsAsync();
    }
}
