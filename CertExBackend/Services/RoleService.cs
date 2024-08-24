using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;

namespace CertExBackend.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public RoleService(
            IRoleRepository roleRepository,
            IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
        {
            var roles = await _roleRepository.GetAllRolesAsync();
            return _mapper.Map<IEnumerable<RoleDto>>(roles);
        }

        public async Task<RoleDto> GetRoleByIdAsync(int id)
        {
            var role = await _roleRepository.GetRoleByIdAsync(id);
            return _mapper.Map<RoleDto>(role);
        }

        public async Task AddRoleAsync(RoleDto roleDto)
        {
            var role = _mapper.Map<Role>(roleDto);
            await _roleRepository.AddRoleAsync(role);
        }

        public async Task UpdateRoleAsync(RoleDto roleDto)
        {
            var role = _mapper.Map<Role>(roleDto);
            await _roleRepository.UpdateRoleAsync(role);
        }

        public async Task DeleteRoleAsync(int id)
        {
            await _roleRepository.DeleteRoleAsync(id);
        }
    }
}
