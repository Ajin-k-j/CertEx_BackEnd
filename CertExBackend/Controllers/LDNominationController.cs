// Controllers/LDNominationController.cs
using CertExBackend.DTOs;
using CertExBackend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LDNominationController : ControllerBase
    {
        private readonly ILDNominationService _nominationService;

        public LDNominationController(ILDNominationService nominationService)
        {
            _nominationService = nominationService;
        }

        // GET: api/ldnomination/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<LDNominationDto>> GetNomination(int id)
        {
            try
            {
                var nomination = await _nominationService.GetNominationByIdAsync(id);
                if (nomination == null)
                {
                    return NotFound();
                }
                return Ok(nomination);
            }
            catch (Exception ex)
            {
                // Log the exception (use a logging framework in a real application)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/ldnomination
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LDNominationDto>>> GetNominations()
        {
            try
            {
                var nominations = await _nominationService.GetAllNominationsAsync();
                return Ok(nominations);
            }
            catch (Exception ex)
            {
                // Log the exception (use a logging framework in a real application)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
