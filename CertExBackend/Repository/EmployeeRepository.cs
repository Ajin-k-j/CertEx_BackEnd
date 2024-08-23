using CertExBackend.Data;
using CertExBackend.Interfaces;
using CertExBackend.Model;

namespace CertExBackend.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApiDbContext _dbContext;

        public EmployeeRepository(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _dbContext.Employees.ToList();
        }

        public Employee GetEmployeeById(int id)
        {
            return _dbContext.Employees.Find(id);
        }

        public void AddEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
        }

        public void UpdateEmployee(Employee employee)
        {
            _dbContext.Employees.Update(employee);
            _dbContext.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            var employee = _dbContext.Employees.Find(id);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                _dbContext.SaveChanges();
            }
        }
    }
}
