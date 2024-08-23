using CertExBackend.Data;
using CertExBackend.Interfaces;
using CertExBackend.Model;

namespace CertExBackend.Repository
{
    public class NominationRepository : INominationRepository
    {
        private readonly ApiDbContext _dbContext;

        public NominationRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Nomination> GetAllNominations()
        {
            return _dbContext.Nominations.ToList();
        }

        public Nomination GetNominationById(int id)
        {
            return _dbContext.Nominations.Find(id);
        }

        public void AddNomination(Nomination nomination)
        {
            _dbContext.Nominations.Add(nomination);
            _dbContext.SaveChanges();
        }

        public void UpdateNomination(Nomination nomination)
        {
            _dbContext.Nominations.Update(nomination);
            _dbContext.SaveChanges();
        }

        public void DeleteNomination(int id)
        {
            var nomination = _dbContext.Nominations.Find(id);
            if (nomination != null)
            {
                _dbContext.Nominations.Remove(nomination);
                _dbContext.SaveChanges();
            }
        }
    }
}
