using CertExBackend.Model;

namespace CertExBackend.Interfaces
{
    public interface INominationRepository
    {
        IEnumerable<Nomination> GetAllNominations();
        Nomination GetNominationById(int id);
        void AddNomination(Nomination nomination);
        void UpdateNomination(Nomination nomination);
        void DeleteNomination(int id);
    }
}
