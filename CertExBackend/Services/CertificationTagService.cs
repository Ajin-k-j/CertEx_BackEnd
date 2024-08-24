using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;

namespace CertExBackend.Services
{
    public class CertificationTagService : ICertificationTagService
    {
        private readonly ICertificationTagRepository _certificationTagRepository;
        private readonly IMapper _mapper;

        public CertificationTagService(
            ICertificationTagRepository certificationTagRepository,
            IMapper mapper)
        {
            _certificationTagRepository = certificationTagRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CertificationTagDto>> GetAllCertificationTagsAsync()
        {
            var certificationTags = await _certificationTagRepository.GetAllCertificationTagsAsync();
            return _mapper.Map<IEnumerable<CertificationTagDto>>(certificationTags);
        }

        public async Task<CertificationTagDto> GetCertificationTagByIdAsync(int id)
        {
            var certificationTag = await _certificationTagRepository.GetCertificationTagByIdAsync(id);
            return _mapper.Map<CertificationTagDto>(certificationTag);
        }

        public async Task AddCertificationTagAsync(CertificationTagDto certificationTagDto)
        {
            var certificationTag = _mapper.Map<CertificationTag>(certificationTagDto);
            await _certificationTagRepository.AddCertificationTagAsync(certificationTag);
        }

        public async Task UpdateCertificationTagAsync(CertificationTagDto certificationTagDto)
        {
            var certificationTag = _mapper.Map<CertificationTag>(certificationTagDto);
            await _certificationTagRepository.UpdateCertificationTagAsync(certificationTag);
        }

        public async Task DeleteCertificationTagAsync(int id)
        {
            await _certificationTagRepository.DeleteCertificationTagAsync(id);
        }
    }
}
