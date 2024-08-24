using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("allroles")]
        public async Task<ActionResult<IEnumerable<RoleDto>>> AllRoles()
        {
            var roles = await _roleService.GetAllRolesAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleDto>> GetRoleById(int id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound(new { Message = $"Role with ID {id} not found." });
            }
            return Ok(role);
        }

        [HttpPost]
        public async Task<ActionResult> AddRole(RoleDto roleDto)
        {
            await _roleService.AddRoleAsync(roleDto);
            return CreatedAtAction(nameof(GetRoleById), new { id = roleDto.Id }, roleDto);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateRole(RoleDto roleDto)
        {
            var existingRole = await _roleService.GetRoleByIdAsync(roleDto.Id);
            if (existingRole == null)
            {
                return NotFound(new { Message = $"Role with ID {roleDto.Id} not found." });
            }
            await _roleService.UpdateRoleAsync(roleDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRole(int id)
        {
            var existingRole = await _roleService.GetRoleByIdAsync(id);
            if (existingRole == null)
            {
                return NotFound(new { Message = $"Role with ID {id} not found." });
            }
            await _roleService.DeleteRoleAsync(id);
            return NoContent();
        }
    }
}