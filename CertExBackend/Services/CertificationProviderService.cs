using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;

namespace CertExBackend.Services
{
    public class CertificationProviderService : ICertificationProviderService
    {
        private readonly ICertificationProviderRepository _certificationProviderRepository;
        private readonly IMapper _mapper;

        public CertificationProviderService(
            ICertificationProviderRepository certificationProviderRepository,
            IMapper mapper)
        {
            _certificationProviderRepository = certificationProviderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CertificationProviderDto>> GetAllCertificationProvidersAsync()
        {
            var certificationProviders = await _certificationProviderRepository.GetAllCertificationProvidersAsync();
            return _mapper.Map<IEnumerable<CertificationProviderDto>>(certificationProviders);
        }

        public async Task<CertificationProviderDto> GetCertificationProviderByIdAsync(int id)
        {
            var certificationProvider = await _certificationProviderRepository.GetCertificationProviderByIdAsync(id);
            return _mapper.Map<CertificationProviderDto>(certificationProvider);
        }

        public async Task AddCertificationProviderAsync(CertificationProviderDto certificationProviderDto)
        {
            var certificationProvider = _mapper.Map<CertificationProvider>(certificationProviderDto);
            await _certificationProviderRepository.AddCertificationProviderAsync(certificationProvider);
        }

        public async Task UpdateCertificationProviderAsync(CertificationProviderDto certificationProviderDto)
        {
            var certificationProvider = _mapper.Map<CertificationProvider>(certificationProviderDto);
            await _certificationProviderRepository.UpdateCertificationProviderAsync(certificationProvider);
        }

        public async Task DeleteCertificationProviderAsync(int id)
        {
            await _certificationProviderRepository.DeleteCertificationProviderAsync(id);
        }
    }
}
