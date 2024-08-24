using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;

namespace CertExBackend.Services
{
    public class MyCertificationService : IMyCertificationService
    {
        private readonly IMyCertificationRepository _myCertificationRepository;
        private readonly IMapper _mapper;

        public MyCertificationService(
            IMyCertificationRepository myCertificationRepository,
            IMapper mapper)
        {
            _myCertificationRepository = myCertificationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MyCertificationDto>> GetAllMyCertificationsAsync()
        {
            var myCertifications = await _myCertificationRepository.GetAllMyCertificationsAsync();
            return _mapper.Map<IEnumerable<MyCertificationDto>>(myCertifications);
        }

        public async Task<MyCertificationDto> GetMyCertificationByIdAsync(int id)
        {
            var myCertification = await _myCertificationRepository.GetMyCertificationByIdAsync(id);
            return _mapper.Map<MyCertificationDto>(myCertification);
        }

        public async Task AddMyCertificationAsync(MyCertificationDto myCertificationDto)
        {
            var myCertification = _mapper.Map<MyCertification>(myCertificationDto);
            await _myCertificationRepository.AddMyCertificationAsync(myCertification);
        }

        public async Task UpdateMyCertificationAsync(MyCertificationDto myCertificationDto)
        {
            var myCertification = _mapper.Map<MyCertification>(myCertificationDto);
            await _myCertificationRepository.UpdateMyCertificationAsync(myCertification);
        }

        public async Task DeleteMyCertificationAsync(int id)
        {
            await _myCertificationRepository.DeleteMyCertificationAsync(id);
        }
    }
}
