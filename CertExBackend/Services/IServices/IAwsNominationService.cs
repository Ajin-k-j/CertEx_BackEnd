using System.Collections.Generic;
using CertExBackend.DTO;

namespace CertExBackend.Services
{
    public interface IAwsNominationService
    {
        AwsNominationDto GetAwsNominationDto(int nominationId);
        IEnumerable<AwsNominationDto> GetAllAwsNominations();
    }
}
