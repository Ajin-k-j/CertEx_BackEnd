using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;

namespace CertExBackend.Services
{
    public class AwsAdminService : IAwsAdminService
    {
        private readonly IAwsAdminRepository _repository;
        private readonly IMapper _mapper;

        public AwsAdminService(IAwsAdminRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AwsAdminDto>> GetAllAwsAdminsAsync()
        {
            var awsAdmins = await _repository.GetAllAwsAdminsAsync();
            return _mapper.Map<IEnumerable<AwsAdminDto>>(awsAdmins);
        }

        public async Task<AwsAdminDto> GetAwsAdminByIdAsync(int id)
        {
            var awsAdmin = await _repository.GetAwsAdminByIdAsync(id);
            return _mapper.Map<AwsAdminDto>(awsAdmin);
        }

        public async Task AddAwsAdminAsync(AwsAdminDto awsAdminDto)
        {
            var awsAdmin = _mapper.Map<AwsAdmin>(awsAdminDto);
            await _repository.AddAwsAdminAsync(awsAdmin);
        }

        public async Task UpdateAwsAdminAsync(AwsAdminDto awsAdminDto)
        {
            var awsAdmin = _mapper.Map<AwsAdmin>(awsAdminDto);
            await _repository.UpdateAwsAdminAsync(awsAdmin);
        }

        public async Task DeleteAwsAdminAsync(int id)
        {
            await _repository.DeleteAwsAdminAsync(id);
        }
    }
}
