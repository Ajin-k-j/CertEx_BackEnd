using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Repository;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;
namespace CertExBackend.Services
{
    public class UserActionFlowService : IUserActionFlowService
    {

        private readonly IUserActionFlowRepository _repository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        public UserActionFlowService(IUserActionFlowRepository repository, IMapper mapper, IWebHostEnvironment env)
        {
            _repository = repository;
            _mapper = mapper;
            _env = env;
        }

        public async Task<ActionFlowCertificationDto> GetCertificationDetailsAsync(int nominationId)
        {
            var nomination = await _repository.GetNominationByIdAsync(nominationId);
            if (nomination == null) return null;

            if (nomination.NominationStatus == "Not Completed" &&
                nomination.CertificationExam.NominationStatus == "Accepting")
            {
                return _mapper.Map<ActionFlowCertificationDto>(nomination.CertificationExam);
            }
            return null;
        }

        public async Task<ActionFlowProviderDto> GetProviderDetailsAsync(int nominationId)
        {
            var nomination = await _repository.GetNominationByIdAsync(nominationId);
            if (nomination == null) return null;

            return _mapper.Map<ActionFlowProviderDto>(nomination.CertificationExam.CertificationProvider);
        }

        public async Task<ActionFlowNominationDto> GetNominationDatesAsync(int nominationId)
        {
            var nomination = await _repository.GetNominationByIdAsync(nominationId);
            if (nomination == null) return null;

            return _mapper.Map<ActionFlowNominationDto>(nomination.CertificationExam);
        }

        public async Task<bool> SetExamDateAsync(int nominationId, DateTime examDate)
        {
            var nomination = await _repository.GetNominationByIdAsync(nominationId);
            if (nomination == null) return false;

            if (nomination.CertificationExam.NominationOpenDate <= examDate &&
                nomination.CertificationExam.NominationCloseDate >= examDate)
            {
                nomination.ExamDate = examDate;
                await _repository.UpdateNominationAsync(nomination);
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateExamStatusAsync(int nominationId, string examStatus)
        {
            var nomination = await _repository.GetNominationByIdAsync(nominationId);
            if (nomination == null) return false;

            nomination.ExamStatus = examStatus;
            await _repository.UpdateNominationAsync(nomination);
            return true;
        }

        


        public async Task<bool> UploadCertificationAsync(ActionFlowMyCertificationDto certificationDto)
        {
            return await _repository.UploadCertificationAsync(certificationDto);
        }

        public async Task<bool> PostInvoiceDetailsAsync(ActionFlowExamDetailDto examDetailDto)
        {
            {
                return await _repository.PostInvoiceDetailsAsync(examDetailDto);
            }
        }
        public async Task DeleteCertificationAsync(int id)
        {
            var certification = await _repository.GetByIdAsync(id);
            if (certification != null)
            {
                // Remove file from wwwroot
                var filePath = Path.Combine(_env.WebRootPath, "uploads", certification.Url);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }

                // Delete record from database
                await _repository.DeleteAsync(id);
            }
        }

        }
}



