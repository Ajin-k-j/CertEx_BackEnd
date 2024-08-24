using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;

namespace CertExBackend.Services
{
    public class CriticalCertificationService : ICriticalCertificationService
    {
        private readonly ICriticalCertificationRepository _criticalCertificationRepository;
        private readonly IMapper _mapper;

        public CriticalCertificationService(
            ICriticalCertificationRepository criticalCertificationRepository,
            IMapper mapper)
        {
            _criticalCertificationRepository = criticalCertificationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CriticalCertificationDto>> GetAllCriticalCertificationsAsync()
        {
            var criticalCertifications = await _criticalCertificationRepository.GetAllCriticalCertificationsAsync();
            return _mapper.Map<IEnumerable<CriticalCertificationDto>>(criticalCertifications);
        }

        public async Task<CriticalCertificationDto> GetCriticalCertificationByIdAsync(int id)
        {
            var criticalCertification = await _criticalCertificationRepository.GetCriticalCertificationByIdAsync(id);
            return _mapper.Map<CriticalCertificationDto>(criticalCertification);
        }

        public async Task AddCriticalCertificationAsync(CriticalCertificationDto criticalCertificationDto)
        {
            var criticalCertification = _mapper.Map<CriticalCertification>(criticalCertificationDto);
            await _criticalCertificationRepository.AddCriticalCertificationAsync(criticalCertification);
        }

        public async Task UpdateCriticalCertificationAsync(CriticalCertificationDto criticalCertificationDto)
        {
            var criticalCertification = _mapper.Map<CriticalCertification>(criticalCertificationDto);
            await _criticalCertificationRepository.UpdateCriticalCertificationAsync(criticalCertification);
        }

        public async Task DeleteCriticalCertificationAsync(int id)
        {
            await _criticalCertificationRepository.DeleteCriticalCertificationAsync(id);
        }
    }
}
