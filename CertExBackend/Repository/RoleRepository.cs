using CertExBackend.Data;
using CertExBackend.Interfaces;
using CertExBackend.Model;

namespace CertExBackend.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApiDbContext _dbContext;

        public RoleRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _dbContext.Roles.ToList();
        }

        public Role GetRoleById(int id)
        {
            return _dbContext.Roles.Find(id);
        }

        public void AddRole(Role role)
        {
            _dbContext.Roles.Add(role);
            _dbContext.SaveChanges();
        }

        public void UpdateRole(Role role)
        {
            _dbContext.Roles.Update(role);
            _dbContext.SaveChanges();
        }

        public void DeleteRole(int id)
        {
            var role = _dbContext.Roles.Find(id);
            if (role != null)
            {
                _dbContext.Roles.Remove(role);
                _dbContext.SaveChanges();
            }
        }
    }
}
