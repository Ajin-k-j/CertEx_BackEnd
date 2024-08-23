using CertExBackend.Model;

namespace CertExBackend.Interfaces
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAllRoles();
        Role GetRoleById(int id);
        void AddRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(int id);
    }
}
