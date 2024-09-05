// Repositories/Interfaces/ILDNominationRepository.cs
using CertExBackend.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CertExBackend.Repositories.Interfaces
{
    public interface ILDNominationRepository
    {
        Task<Nomination> GetNominationByIdAsync(int id);
        Task<IEnumerable<Nomination>> GetAllNominationsAsync();
    }
}