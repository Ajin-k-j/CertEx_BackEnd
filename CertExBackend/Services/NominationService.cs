using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;

namespace CertExBackend.Services
{
    public class NominationService : INominationService
    {
        private readonly INominationRepository _nominationRepository;
        private readonly IMapper _mapper;

        public NominationService(
            INominationRepository nominationRepository,
            IMapper mapper)
        {
            _nominationRepository = nominationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NominationDto>> GetAllNominationsAsync()
        {
            var nominations = await _nominationRepository.GetAllNominationsAsync();
            return _mapper.Map<IEnumerable<NominationDto>>(nominations);
        }

        public async Task<NominationDto> GetNominationByIdAsync(int id)
        {
            var nomination = await _nominationRepository.GetNominationByIdAsync(id);
            return _mapper.Map<NominationDto>(nomination);
        }

        public async Task AddNominationAsync(NominationDto nominationDto)
        {
            var nomination = _mapper.Map<Nomination>(nominationDto);
            await _nominationRepository.AddNominationAsync(nomination);
        }

        public async Task UpdateNominationAsync(NominationDto nominationDto)
        {
            var nomination = _mapper.Map<Nomination>(nominationDto);
            await _nominationRepository.UpdateNominationAsync(nomination);
        }

        public async Task DeleteNominationAsync(int id)
        {
            await _nominationRepository.DeleteNominationAsync(id);
        }
    }
}
