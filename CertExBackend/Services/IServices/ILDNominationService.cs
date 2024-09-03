// Services/Interfaces/ILDNominationService.cs
using CertExBackend.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CertExBackend.Services.Interfaces
{
    public interface ILDNominationService
    {
        Task<LDNominationDto> GetNominationByIdAsync(int id);
        Task<IEnumerable<LDNominationDto>> GetAllNominationsAsync();
    }
}
