using CertExBackend.Data;
using CertExBackend.Interfaces;
using CertExBackend.Model;

namespace CertExBackend.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApiDbContext _dbContext;

        public DepartmentRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _dbContext.Departments.ToList();
        }

        public Department GetDepartmentById(int id)
        {
            return _dbContext.Departments.Find(id);
        }

        public void AddDepartment(Department department)
        {
            _dbContext.Departments.Add(department);
            _dbContext.SaveChanges();
        }

        public void UpdateDepartment(Department department)
        {
            _dbContext.Departments.Update(department);
            _dbContext.SaveChanges();
        }

        public void DeleteDepartment(int id)
        {
            var department = _dbContext.Departments.Find(id);
            if (department != null)
            {
                _dbContext.Departments.Remove(department);
                _dbContext.SaveChanges();
            }
        }
    }
}
