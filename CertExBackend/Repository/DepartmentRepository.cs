using CertExBackend.Data;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CertExBackend.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApiDbContext _dbContext;

        public DepartmentRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _dbContext.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return await _dbContext.Departments.FindAsync(id);
        }

        public async Task AddDepartmentAsync(Department department)
        {
            _dbContext.Departments.Add(department);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            _dbContext.Departments.Update(department);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var department = await _dbContext.Departments.FindAsync(id);
            if (department != null)
            {
                _dbContext.Departments.Remove(department);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
