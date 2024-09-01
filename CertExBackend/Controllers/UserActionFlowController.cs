using CertExBackend.Services.IServices;
using CertExBackend.DTOs;
using Microsoft.AspNetCore.Mvc;
using CertExBackend.Services;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserActionFlowController : ControllerBase
    {
        private readonly IUserActionFlowService _actionFlowService;

        public UserActionFlowController(IUserActionFlowService actionflowService)
        {
            _actionFlowService = actionflowService;
        }

        [HttpGet("{nominationId}/certification-details")]
        public async Task<IActionResult> GetCertificationDetails(int nominationId)
        {
            var certificationDetails = await _actionFlowService.GetCertificationDetailsAsync(nominationId);
            if (certificationDetails == null)
                return NotFound();

            return Ok(certificationDetails);
        }

        [HttpGet("{nominationId}/provider-details")]
        public async Task<IActionResult> GetProviderDetails(int nominationId)
        {
            var providerDetails = await _actionFlowService.GetProviderDetailsAsync(nominationId);
            if (providerDetails == null)
                return NotFound();

            return Ok(providerDetails);
        }

        [HttpGet("{nominationId}/nomination-dates")]
        public async Task<IActionResult> GetNominationDates(int nominationId)
        {
            var nominationDates = await _actionFlowService.GetNominationDatesAsync(nominationId);
            if (nominationDates == null)
                return NotFound();

            return Ok(nominationDates);
        }

        [HttpPatch("{nominationId}/set-exam-date")]
        public async Task<IActionResult> SetExamDate(int nominationId, [FromBody] DateTime examDate)
        {
            var result = await _actionFlowService.SetExamDateAsync(nominationId, examDate);
            if (!result)
                return BadRequest("Invalid exam date");

            return Ok();
        }

        [HttpPatch("{nominationId}/update-exam-status")]
        public async Task<IActionResult> UpdateExamStatus(int nominationId, [FromBody] string examStatus)
        {
            var result = await _actionFlowService.UpdateExamStatusAsync(nominationId, examStatus);
            if (!result)
                return BadRequest("Unable to update exam status");

            return Ok();
        }


        /*   [HttpPost("{nominationId}/upload-certification")]
           public async Task<IActionResult> UploadCertification(int nominationId, [FromForm] ActionFlowMyCertificationDto certificationDto)
           {
               var result = await _actionFlowService.UploadCertificationAsync(nominationId, certificationDto);
               if (!result)
                   return BadRequest("Unable to upload certification");

               return Ok("Certification uploaded successfully");
           }*/

        [HttpPost("upload-certification")]
        public async Task<IActionResult> UploadCertification([FromForm] ActionFlowMyCertificationDto certificationDto)
        {
            var result = await _actionFlowService.UploadCertificationAsync(certificationDto);
            if (!result)
                return BadRequest("Unable to upload certification");

            return Ok("Certification uploaded successfully");
        }



        [HttpPost("{nominationId}/post-invoice-details")]
        public async Task<IActionResult> PostInvoiceDetails(int nominationId, [FromBody] ActionFlowExamDetailDto userflowexamDetailDto)
        {
            var result = await _actionFlowService.PostInvoiceDetailsAsync(nominationId, userflowexamDetailDto);
            if (!result)
                return BadRequest("Unable to post invoice details");

            return Ok("Invoice details posted successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _actionFlowService.DeleteCertificationAsync(id);
            return NoContent();
        }

    }
}




