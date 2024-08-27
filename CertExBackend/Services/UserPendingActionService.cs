using CertExBackend.DTOs;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;

namespace CertExBackend.Services
{
    public class UserPendingActionService : IUserPendingActionService
    {
        private readonly IUserPendingActionRepository _repository;

        public UserPendingActionService(IUserPendingActionRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<UserPendingActionDto>> GetUserPendingActionsAsync()
        {
            // Hardcoding EmployeeId as 1
            int employeeId = 1;
            return _repository.GetUserPendingActionsAsync(employeeId);
        }
    }
}
