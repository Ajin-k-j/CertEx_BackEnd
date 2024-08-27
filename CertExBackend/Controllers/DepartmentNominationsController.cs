using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class DepartmentNominationsController : ControllerBase
{
    private readonly IDepartmentNominationService _service;

    public DepartmentNominationsController(IDepartmentNominationService service)
    {
        _service = service;
    }

    [HttpGet("{departmentId}")]
    public async Task<IActionResult> GetNominations(int departmentId)
    {
        var nominations = await _service.GetNominationsByDepartmentAsync(departmentId);
        return Ok(nominations);
    }
}
