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
    public async Task<IActionResult> GetCertifications(int employeeId)
    {
        var certifications = await _service.GetCertificationsByEmployeeIdAsync(employeeId);
        if (certifications == null || !certifications.Any())
        {
            return NotFound();
        }
        return Ok(certifications);
    }
}
