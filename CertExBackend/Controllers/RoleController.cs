using CertExBackend.Interfaces;
using CertExBackend.Model;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RoleController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Role>> GetAllRoles()
        {
            var roles = _roleRepository.GetAllRoles();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public ActionResult<Role> GetRoleById(int id)
        {
            var role = _roleRepository.GetRoleById(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        [HttpPost]
        public ActionResult AddRole([FromBody] Role role)
        {
            _roleRepository.AddRole(role);
            return CreatedAtAction(nameof(GetRoleById), new { id = role.Id }, role);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRole(int id, [FromBody] Role role)
        {
            var existingRole = _roleRepository.GetRoleById(id);

            if (existingRole == null)
            {
                return NotFound();
            }

            existingRole.Name = role.Name;
            existingRole.UpdatedAt = DateTime.UtcNow;
            existingRole.UpdatedBy = role.UpdatedBy;

            _roleRepository.UpdateRole(existingRole);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            var role = _roleRepository.GetRoleById(id);
            if (role == null)
            {
                return NotFound();
            }

            _roleRepository.DeleteRole(id);
            return NoContent();
        }
    }
}
