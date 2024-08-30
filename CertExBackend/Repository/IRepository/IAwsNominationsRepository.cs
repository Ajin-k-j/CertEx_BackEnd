using System.Collections.Generic;
using CertExBackend.Model;

namespace CertExBackend.Repositories
{
    public interface IAwsNominationRepository
    {
        Nomination GetNomination(int nominationId);
        bool IsCertificationCritical(int certificationId);
        IEnumerable<Nomination> GetAllAwsNominations();
    }
}
