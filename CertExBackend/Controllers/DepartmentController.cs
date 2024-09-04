using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet("alldepartments")]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> AllDepartments()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetDepartmentById(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return NotFound(new { Message = $"Department with ID {id} not found." });
            }
            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult> AddDepartment(Department department)
        {
            await _departmentService.AddDepartmentAsync(department);
            return CreatedAtAction(nameof(GetDepartmentById), new { id = department.Id }, department);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateDepartment(DepartmentDto departmentDto)
        {
            var existingDepartment = await _departmentService.GetDepartmentByIdAsync(departmentDto.Id);
            if (existingDepartment == null)
            {
                return NotFound(new { Message = $"Department with ID {departmentDto.Id} not found." });
            }

            await _departmentService.UpdateDepartmentAsync(departmentDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(int id)
        {
            var existingDepartment = await _departmentService.GetDepartmentByIdAsync(id);
            if (existingDepartment == null)
            {
                return NotFound(new { Message = $"Department with ID {id} not found." });
            }

            await _departmentService.DeleteDepartmentAsync(id);
            return NoContent();
        }
    }
}