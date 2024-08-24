using CertExBackend.DTOs;

namespace CertExBackend.Services.IServices
{
    public interface IAwsAdminService
    {
        Task<IEnumerable<AwsAdminDto>> GetAllAwsAdminsAsync();
        Task<AwsAdminDto> GetAwsAdminByIdAsync(int id);
        Task AddAwsAdminAsync(AwsAdminDto awsAdminDto);
        Task UpdateAwsAdminAsync(AwsAdminDto awsAdminDto);
        Task DeleteAwsAdminAsync(int id);
    }
}
