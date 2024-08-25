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
    }
}
