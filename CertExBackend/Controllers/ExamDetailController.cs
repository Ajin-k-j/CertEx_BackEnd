using CertExBackend.Interfaces;
using CertExBackend.Model;
using Microsoft.AspNetCore.Mvc;

namespace CertExBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExamDetailController : ControllerBase
    {
        private readonly IExamDetailRepository _examDetailRepository;

        public ExamDetailController(IExamDetailRepository examDetailRepository)
        {
            _examDetailRepository = examDetailRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ExamDetail>> GetAllExamDetails()
        {
            var examDetails = _examDetailRepository.GetAllExamDetails();
            return Ok(examDetails);
        }

        [HttpGet("{id}")]
        public ActionResult<ExamDetail> GetExamDetailById(int id)
        {
            var examDetail = _examDetailRepository.GetExamDetailById(id);
            if (examDetail == null)
            {
                return NotFound();
            }
            return Ok(examDetail);
        }

        [HttpPost]
        public ActionResult AddExamDetail([FromBody] ExamDetail examDetail)
        {
            _examDetailRepository.AddExamDetail(examDetail);
            return CreatedAtAction(nameof(GetExamDetailById), new { id = examDetail.Id }, examDetail);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateExamDetail(int id, [FromBody] ExamDetail examDetail)
        {
            var existingExamDetail = _examDetailRepository.GetExamDetailById(id);

            if (existingExamDetail == null)
            {
                return NotFound();
            }

            existingExamDetail.NominationId = examDetail.NominationId;
            existingExamDetail.MyCertificationId = examDetail.MyCertificationId;
            existingExamDetail.CostInrWithoutTax = examDetail.CostInrWithoutTax;
            existingExamDetail.CostInrWithTax = examDetail.CostInrWithTax;
            existingExamDetail.InvoiceNumber = examDetail.InvoiceNumber;
            existingExamDetail.InvoiceUrl = examDetail.InvoiceUrl;
            existingExamDetail.UploadCertificateStatus = examDetail.UploadCertificateStatus;
            existingExamDetail.SkillMatrixStatus = examDetail.SkillMatrixStatus;
            existingExamDetail.ReimbursementStatus = examDetail.ReimbursementStatus;
            existingExamDetail.UpdatedAt = DateTime.UtcNow;
            existingExamDetail.UpdatedBy = examDetail.UpdatedBy;

            _examDetailRepository.UpdateExamDetail(existingExamDetail);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteExamDetail(int id)
        {
            var examDetail = _examDetailRepository.GetExamDetailById(id);
            if (examDetail == null)
            {
                return NotFound();
            }

            _examDetailRepository.DeleteExamDetail(id);
            return NoContent();
        }
    }
}
