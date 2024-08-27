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

        public async Task AddCertificationExamAsync(CertificationExam certificationExam)
        {
            await _certificationExamRepository.AddCertificationExamAsync(certificationExam);
        }

        public async Task UpdateCertificationExamAsync(CertificationExam certificationExam)
        {
            // Fetch the existing entity from the repository
            var existingExam = await _certificationExamRepository.GetCertificationExamByIdAsync(certificationExam.Id);
            if (existingExam == null)
            {
                throw new ArgumentException($"CertificationExam with ID {certificationExam.Id} not found.");
            }

            // Update properties of the existing entity with new values
            existingExam.ProviderId = certificationExam.ProviderId;
            existingExam.CertificationName = certificationExam.CertificationName;
            existingExam.NominationStatus = certificationExam.NominationStatus;
            existingExam.Level = certificationExam.Level;
            existingExam.Description = certificationExam.Description;
            existingExam.Views = certificationExam.Views;
            existingExam.OfficialLink = certificationExam.OfficialLink;
            existingExam.CostUsd = certificationExam.CostUsd;
            existingExam.CostInr = certificationExam.CostInr;
            existingExam.NominationOpenDate = certificationExam.NominationOpenDate;
            existingExam.NominationCloseDate = certificationExam.NominationCloseDate;
            existingExam.UpdatedAt = DateTime.UtcNow;
            existingExam.UpdatedBy = certificationExam.UpdatedBy; 

            // Update the existing entity
            await _certificationExamRepository.UpdateCertificationExamAsync(existingExam);
        }



        public async Task DeleteCertificationExamAsync(int id)
        {
            await _certificationExamRepository.DeleteCertificationExamAsync(id);
        }
    }
}
