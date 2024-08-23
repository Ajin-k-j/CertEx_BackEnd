using CertExBackend.Interfaces;
using CertExBackend.Model;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Department>> GetAllDepartments()
        {
            var departments = _departmentRepository.GetAllDepartments();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public ActionResult<Department> GetDepartmentById(int id)
        {
            var department = _departmentRepository.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        [HttpPost]
        public ActionResult AddDepartment([FromBody] Department department)
        {
            _departmentRepository.AddDepartment(department);
            return CreatedAtAction(nameof(GetDepartmentById), new { id = department.Id }, department);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDepartment(int id, [FromBody] Department department)
        {
            var existingDepartment = _departmentRepository.GetDepartmentById(id);

            if (existingDepartment == null)
            {
                return NotFound();
            }

            existingDepartment.DepartmentName = department.DepartmentName;

            _departmentRepository.UpdateDepartment(existingDepartment);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {
            var department = _departmentRepository.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }

            _departmentRepository.DeleteDepartment(id);
            return NoContent();
        }
    }
}
