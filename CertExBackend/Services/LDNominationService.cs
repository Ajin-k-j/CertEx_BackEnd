// Services/LDNominationService.cs
using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repositories.Interfaces;
using CertExBackend.Repository;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CertExBackend.Services
{
    public class LDNominationService : ILDNominationService
    {
        private readonly ILDNominationRepository _nominationRepository;
        private readonly IMapper _mapper;
        private readonly IFinancialYearRepository _financialYearRepository;

        public LDNominationService(ILDNominationRepository nominationRepository, IMapper mapper, IFinancialYearRepository financialYearRepository)
        {
            _nominationRepository = nominationRepository;
            _mapper = mapper;
            _financialYearRepository = financialYearRepository;
        }

        private async Task<FinancialYear> DetermineFinancialYearAsync(DateTime nominationDate)
        {
            // Find the FinancialYear that includes the nomination date
            return await _financialYearRepository.GetFinancialYearForDateAsync(nominationDate);
        }


        public async Task<LDNominationDto> GetNominationByIdAsync(int id)
        {
            var nomination = await _nominationRepository.GetNominationByIdAsync(id);
            return _mapper.Map<LDNominationDto>(nomination);
        }

        public async Task<IEnumerable<LDNominationDto>> GetAllNominationsAsync()
        {
            var nominations = await _nominationRepository.GetAllNominationsAsync();
            var dtoList = _mapper.Map<IEnumerable<LDNominationDto>>(nominations);

            foreach (var dto in dtoList)
            {
                var financialYear = await DetermineFinancialYearAsync(dto.NominationDate);
                dto.FinancialYear = $"{financialYear.FromDate.Year}-{financialYear.ToDate.Year}";
            }

            return dtoList;
        }
    }
}