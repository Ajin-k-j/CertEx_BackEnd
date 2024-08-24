using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;

namespace CertExBackend.Services
{
    public class CertificationExamService : ICertificationExamService
    {
        private readonly ICertificationExamRepository _certificationExamRepository;
        private readonly IMapper _mapper;
        private readonly ICertificationProviderRepository _providerRepository; // Repository for provider
        private readonly ICertificationTagRepository _certificationTagRepository; // Repository for certification tags
        private readonly ICategoryTagRepository _categoryTagRepository; // Repository for category tags

        public CertificationExamService(
            ICertificationExamRepository certificationExamRepository,
            IMapper mapper,
            ICertificationProviderRepository providerRepository,
            ICertificationTagRepository certificationTagRepository,
            ICategoryTagRepository categoryTagRepository)
        {
            _certificationExamRepository = certificationExamRepository;
            _mapper = mapper;
            _providerRepository = providerRepository;
            _certificationTagRepository = certificationTagRepository;
            _categoryTagRepository = categoryTagRepository;
        }

        public async Task<IEnumerable<CertificationExamDto>> GetAllCertificationExamsAsync()
        {
            var certificationExams = await _certificationExamRepository.GetAllCertificationExamsAsync();
            var certificationExamDtos = _mapper.Map<IEnumerable<CertificationExamDto>>(certificationExams);

            foreach (var examDto in certificationExamDtos)
            {
                // Fetch provider name using the CertificationExam model
                var certificationExam = certificationExams.FirstOrDefault(exam => exam.Id == examDto.Id);
                if (certificationExam != null)
                {
                    var provider = await _providerRepository.GetCertificationProviderByIdAsync(certificationExam.ProviderId);
                    examDto.ProviderName = provider?.ProviderName ?? "Unknown";

                    // Fetch tags related to the certification exam
                    var certificationTags = await _certificationTagRepository.GetAllCertificationTagsAsync();
                    var categoryTags = await _categoryTagRepository.GetAllCategoryTagsAsync();

                    examDto.Tags = certificationTags
                        .Where(ct => ct.CertificationId == certificationExam.Id)
                        .Select(ct => ct.CategoryTagId)
                        .Distinct()
                        .Select(categoryTagId => categoryTags.FirstOrDefault(tag => tag.Id == categoryTagId)?.CategoryTagName)
                        .Where(tagName => tagName != null)
                        .ToList();
                }
            }

            return certificationExamDtos;
        }

        public async Task<CertificationExamDto> GetCertificationExamByIdAsync(int id)
        {
            var certificationExam = await _certificationExamRepository.GetCertificationExamByIdAsync(id);
            if (certificationExam == null)
            {
                return null;
            }

            var certificationExamDto = _mapper.Map<CertificationExamDto>(certificationExam);

            // Fetch provider name
            var provider = await _providerRepository.GetCertificationProviderByIdAsync(certificationExam.ProviderId);
            certificationExamDto.ProviderName = provider?.ProviderName ?? "Unknown";

            // Fetch tags
            var certificationTags = await _certificationTagRepository.GetAllCertificationTagsAsync();
            var categoryTags = await _categoryTagRepository.GetAllCategoryTagsAsync();

            certificationExamDto.Tags = certificationTags
                .Where(ct => ct.CertificationId == certificationExam.Id)
                .Select(ct => ct.CategoryTagId)
                .Distinct()
                .Select(categoryTagId => categoryTags.FirstOrDefault(tag => tag.Id == categoryTagId)?.CategoryTagName)
                .Where(tagName => tagName != null)
                .ToList();

            return certificationExamDto;
        }

        public async Task AddCertificationExamAsync(CertificationExamDto certificationExamDto)
        {
            var certificationExam = _mapper.Map<CertificationExam>(certificationExamDto);
            await _certificationExamRepository.AddCertificationExamAsync(certificationExam);
        }

        public async Task UpdateCertificationExamAsync(CertificationExamDto certificationExamDto)
        {
            var certificationExam = _mapper.Map<CertificationExam>(certificationExamDto);
            await _certificationExamRepository.UpdateCertificationExamAsync(certificationExam);
        }

        public async Task DeleteCertificationExamAsync(int id)
        {
            await _certificationExamRepository.DeleteCertificationExamAsync(id);
        }
    }
}
