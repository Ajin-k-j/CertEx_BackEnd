using CertExBackend.Interfaces;
using CertExBackend.Model;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public ActionResult AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            _employeeRepository.AddEmployee(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            var existingEmployee = _employeeRepository.GetEmployeeById(id);

            if (existingEmployee == null)
            {
                return NotFound();
            }

            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.DepartmentId = employee.DepartmentId;
            existingEmployee.AppRoleId = employee.AppRoleId;
            existingEmployee.AwsAccountActive = employee.AwsAccountActive;
            existingEmployee.Email = employee.Email;
            existingEmployee.SSOEmployeeId = employee.SSOEmployeeId;
            existingEmployee.ManagerId = employee.ManagerId;
            existingEmployee.IsManager = employee.IsManager;
            existingEmployee.IsDepartmentHead = employee.IsDepartmentHead;
            existingEmployee.Designation = employee.Designation;

            _employeeRepository.UpdateEmployee(existingEmployee);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            _employeeRepository.DeleteEmployee(id);
            return NoContent();
        }
    }
}
