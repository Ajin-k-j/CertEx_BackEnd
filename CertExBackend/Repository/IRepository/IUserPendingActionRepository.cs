using CertExBackend.DTOs;

namespace CertExBackend.Repository.IRepository
{
    public interface IUserPendingActionRepository
    {
        Task<IEnumerable<UserPendingActionDto>> GetUserPendingActionsAsync(int employeeId);

    }
}
