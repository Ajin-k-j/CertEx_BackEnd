using CertExBackend.Data;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CertExBackend.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApiDbContext _dbContext;

        public EmployeeRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _dbContext.Employees
                .Include(e => e.Department)
                .Include(e => e.Role)
                .Include(e => e.Manager)
                .Include(e => e.Subordinates)
                .Include(e => e.Nominations)
                .ToListAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _dbContext.Employees
                .Include(e => e.Department)
                .Include(e => e.Role)
                .Include(e => e.Manager)
                .Include(e => e.Subordinates)
                .Include(e => e.Nominations)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployeeByUsernameAsync(string username)
        {
            return await _dbContext.Employees.FirstOrDefaultAsync(e => e.SSOEmployeeId == username);
        }
        public async Task UpdateEmployeeAsync(Employee employee)
        {
            _dbContext.Employees.Update(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
