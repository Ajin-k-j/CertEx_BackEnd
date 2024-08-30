using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using CertExBackend.Services.IServices;

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
        var certifications = await _repository.GetCertificationsByEmployeeIdAsync(employeeId);
        return _mapper.Map<IEnumerable<EmployeeCertificationDto>>(certifications);
    }
}
