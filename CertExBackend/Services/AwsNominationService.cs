using AutoMapper;
using CertExBackend.DTO;
using CertExBackend.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace CertExBackend.Services
{
    public class AwsNominationService : IAwsNominationService
    {
        private readonly IAwsNominationRepository _repository;
        private readonly IMapper _mapper;

        public AwsNominationService(IAwsNominationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public AwsNominationDto GetAwsNominationDto(int nominationId)
        {
            var nomination = _repository.GetNomination(nominationId);
            if (nomination == null)
            {
                throw new Exception("Nomination not found");
            }

            var dto = _mapper.Map<AwsNominationDto>(nomination);

            // Determine criticality based on CertificationExam Id
            var isCritical = _repository.IsCertificationCritical(nomination.CertificationExam.Id);
            dto.Criticality = isCritical ? "High" : "Low";

            return dto;
        }

        public IEnumerable<AwsNominationDto> GetAllAwsNominations()
        {
            var nominations = _repository.GetAllAwsNominations();
            var dtos = _mapper.Map<IEnumerable<AwsNominationDto>>(nominations);

            // Set criticality for each DTO
            foreach (var dto in dtos)
            {
                var isCritical = _repository.IsCertificationCritical(dto.NominationId);
                dto.Criticality = isCritical ? "High" : "Low";
            }

            return dtos;
        }
    }
}
