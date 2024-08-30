using CertExBackend.DTOs;

namespace CertExBackend.Services.IServices
{
    public interface IUserPendingActionService
    {
        Task<IEnumerable<UserPendingActionDto>> GetUserPendingActionsAsync();
    }
}
