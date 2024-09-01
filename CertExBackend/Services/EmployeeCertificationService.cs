using AutoMapper;

public class EmployeeCertificationService : IEmployeeCertificationService
{
    private readonly IEmployeeCertificationRepository _repository;
    private readonly IMapper _mapper;

    public EmployeeCertificationService(IEmployeeCertificationRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EmployeeCertificationDto>> GetCertificationsByEmployeeIdAsync(int employeeId)
    {
        var nominations = await _repository.GetPassedCertificationsByEmployeeIdAsync(employeeId);

        // Map nominations to EmployeeCertificationDto
        var certificationDtos = _mapper.Map<IEnumerable<EmployeeCertificationDto>>(nominations);

        return certificationDtos;
    }
}
