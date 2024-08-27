using System.Collections.Generic;
using System.Threading.Tasks;
using CertExBackend.DTOs;
using CertExBackend.Services.IServices;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EmployeeCertificationController : ControllerBase
{
    private readonly IEmployeeCertificationService _service;

    public EmployeeCertificationController(IEmployeeCertificationService service)
    {
        _service = service;
    }

    [HttpGet("{employeeId}")]
    public async Task<ActionResult<IEnumerable<EmployeeCertificationDto>>> GetCertificationsByEmployeeId(int employeeId)
    {
        var certifications = await _service.GetCertificationsByEmployeeIdAsync(employeeId);
        if (certifications == null)
        {
            return NotFound();
        }
        return Ok(certifications);
    }
}
