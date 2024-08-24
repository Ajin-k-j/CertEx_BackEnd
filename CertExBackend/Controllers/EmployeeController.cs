using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("allemployees")]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> AllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeeById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound(new { Message = $"Employee with ID {id} not found." });
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee(EmployeeDto employeeDto)
        {
            await _employeeService.AddEmployeeAsync(employeeDto);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employeeDto.Id }, employeeDto);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEmployee(EmployeeDto employeeDto)
        {
            var existingEmployee = await _employeeService.GetEmployeeByIdAsync(employeeDto.Id);
            if (existingEmployee == null)
            {
                return NotFound(new { Message = $"Employee with ID {employeeDto.Id} not found." });
            }

            await _employeeService.UpdateEmployeeAsync(employeeDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var existingEmployee = await _employeeService.GetEmployeeByIdAsync(id);
            if (existingEmployee == null)
            {
                return NotFound(new { Message = $"Employee with ID {id} not found." });
            }

            await _employeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }
    }
}