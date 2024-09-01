using CertExBackend.DTOs;

namespace CertExBackend.Services.IServices
{
    public interface INominationService
    {
        Task<IEnumerable<NominationDto>> GetAllNominationsAsync();
        Task<NominationDto> GetNominationByIdAsync(int id);
        Task AddNominationAsync(NominationCreateDto nominationCreateDto);
        Task UpdateNominationAsync(NominationDto nominationDto);
        Task DeleteNominationAsync(int id);
        Task ApproveDepartmentAsync(int id);
        Task ApproveLndAsync(int id);
        Task RejectDepartmentAsync(int id); 
        Task RejectLndAsync(int id);      
        Task<IEnumerable<PendingNominationDto>> GetPendingLndApprovalsAsync();
        Task<IEnumerable<PendingNominationDto>> GetPendingDepartmentApprovalsAsync(int departmentId);

        Task<bool> ProcessManagerFeedbackAsync(ManagerFeedbackDto feedbackDto);
    }
}
