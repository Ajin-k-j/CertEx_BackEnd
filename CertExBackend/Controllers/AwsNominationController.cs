using CertExBackend.DTO;
using CertExBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AwsNominationController : ControllerBase
    {
        private readonly IAwsNominationService _service;

        public AwsNominationController(IAwsNominationService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("all")]
        public ActionResult<IEnumerable<AwsNominationDto>> GetAllAwsNominations()
        {
            var awsNominations = _service.GetAllAwsNominations();
            return Ok(awsNominations);
        }

        [HttpGet("{id}")]
        public ActionResult<AwsNominationDto> GetAwsNomination(int id)
        {
            try
            {
                var awsNomination = _service.GetAwsNominationDto(id);
                return Ok(awsNomination);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
