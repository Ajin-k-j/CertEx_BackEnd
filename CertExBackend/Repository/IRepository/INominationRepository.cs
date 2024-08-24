using CertExBackend.Model;

namespace CertExBackend.Repository.IRepository
{
    public interface INominationRepository
    {
        Task<IEnumerable<Nomination>> GetAllNominationsAsync();
        Task<Nomination> GetNominationByIdAsync(int id);
        Task AddNominationAsync(Nomination nomination);
        Task UpdateNominationAsync(Nomination nomination);
        Task DeleteNominationAsync(int id);
    }
}
