using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;

namespace CertExBackend.Services
{
    public class ExamDetailService : IExamDetailService
    {
        private readonly IExamDetailRepository _examDetailRepository;
        private readonly IMapper _mapper;

        public ExamDetailService(
            IExamDetailRepository examDetailRepository,
            IMapper mapper)
        {
            _examDetailRepository = examDetailRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ExamDetailDto>> GetAllExamDetailsAsync()
        {
            var examDetails = await _examDetailRepository.GetAllExamDetailsAsync();
            return _mapper.Map<IEnumerable<ExamDetailDto>>(examDetails);
        }

        public async Task<ExamDetailDto> GetExamDetailByIdAsync(int id)
        {
            var examDetail = await _examDetailRepository.GetExamDetailByIdAsync(id);
            return _mapper.Map<ExamDetailDto>(examDetail);
        }

        public async Task AddExamDetailAsync(ExamDetailDto examDetailDto)
        {
            var examDetail = _mapper.Map<ExamDetail>(examDetailDto);
            await _examDetailRepository.AddExamDetailAsync(examDetail);
        }

        public async Task UpdateExamDetailAsync(ExamDetailDto examDetailDto)
        {
            var examDetail = _mapper.Map<ExamDetail>(examDetailDto);
            await _examDetailRepository.UpdateExamDetailAsync(examDetail);
        }

        public async Task DeleteExamDetailAsync(int id)
        {
            await _examDetailRepository.DeleteExamDetailAsync(id);
        }
    }
}
