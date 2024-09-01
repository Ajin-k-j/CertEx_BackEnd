using CertExBackend.Data;
using CertExBackend.DTOs;
using CertExBackend.Model;
using CertExBackend.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace CertExBackend.Repository
{
    public class UserActionFlowRepository : IUserActionFlowRepository
    {
        private readonly ApiDbContext _dbcontext;
        private readonly IWebHostEnvironment _env;

        public UserActionFlowRepository(ApiDbContext dbcontext, IWebHostEnvironment env)
        {
            _dbcontext = dbcontext;
            _env = env;
        }

        public async Task<Nomination> GetNominationByIdAsync(int nominationId)
        {
            return await _dbcontext.Nominations
                .Include(n => n.CertificationExam)
                .ThenInclude(ce => ce.CertificationProvider)
                .FirstOrDefaultAsync(n => n.Id == nominationId);
        }

        public async Task<CertificationExam> GetCertificationExamByIdAsync(int certificationId)
        {
            return await _dbcontext.CertificationExams
                .Include(ce => ce.CertificationProvider)
                .FirstOrDefaultAsync(ce => ce.Id == certificationId);
        }

        public async Task<CertificationProvider> GetCertificationProviderByIdAsync(int providerId)
        {
            return await _dbcontext.CertificationProviders
                .FirstOrDefaultAsync(cp => cp.Id == providerId);
        }

        public async Task UpdateNominationAsync(Nomination nomination)
        {
            _dbcontext.Nominations.Update(nomination);
            await _dbcontext.SaveChangesAsync();
        }

/*        public async Task<bool> UploadCertificationAsync(int nominationId, ActionFlowMyCertificationDto certificationDto)
        {
            var nomination = await _dbcontext.Nominations
                .Include(n => n.ExamDetails)
                .FirstOrDefaultAsync(n => n.Id == nominationId);

            if (nomination == null)
                return false;

            // Save file to wwwroot/uploads
            var uploadsFolderPath = Path.Combine(_env.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath);
            }

            var fileName = $"{Guid.NewGuid()}_{certificationDto.File.FileName}";
            var filePath = Path.Combine(uploadsFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await certificationDto.File.CopyToAsync(stream);
            }

            // Set the URL to be stored in the database
            var fileUrl = Path.Combine("uploads", fileName);

            var myCertification = new MyCertification
            {
                Filename = certificationDto.File.FileName,
                Url = fileUrl,
                FromDate = certificationDto.FromDate,
                ExpiryDate = certificationDto.ExpiryDate,
                Credentials = certificationDto.Credentials,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "system"
            };

            _dbcontext.MyCertifications.Add(myCertification);
            await _dbcontext.SaveChangesAsync();

            // Update the status
            foreach (var detail in nomination.ExamDetails)
            {
                detail.UploadCertificateStatus = "Uploaded";
                detail.MyCertificationId = myCertification.Id;
                _dbcontext.ExamDetails.Update(detail);
            }

            return await _dbcontext.SaveChangesAsync() > 0;
        }
*/
        public async Task<bool> UploadCertificationAsync(ActionFlowMyCertificationDto certificationDto)
        {
            // Save file to wwwroot/uploads
            var uploadsFolderPath = Path.Combine(_env.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolderPath))
            {
                Directory.CreateDirectory(uploadsFolderPath); // Ensure the directory exists
            }

            var fileName = $"{Guid.NewGuid()}_{certificationDto.File.FileName}";
            var filePath = Path.Combine(uploadsFolderPath, fileName);

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await certificationDto.File.CopyToAsync(stream);
                }
            }
            catch (Exception ex)
            {
                // Log the error here
                Console.WriteLine($"Error uploading file: {ex.Message}");
                return false;
            }

            // Set the URL to be stored in the database
            var fileUrl = Path.Combine("uploads", fileName).Replace("\\", "/"); // Normalize the URL for different OS

            var myCertification = new MyCertification
            {
                Filename = certificationDto.Filename,
                Url = fileUrl,  // Store the relative URL in the database
                FromDate = certificationDto.FromDate,
                ExpiryDate = certificationDto.ExpiryDate,
                Credentials = certificationDto.Credentials,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "system"
            };

            _dbcontext.MyCertifications.Add(myCertification);
            return await _dbcontext.SaveChangesAsync() > 0;
        }

        public async Task<bool> PostInvoiceDetailsAsync(int nominationId, ActionFlowExamDetailDto actionflowexamDetailDto)
        {
            var nomination = await _dbcontext.Nominations
                .Include(n => n.ExamDetails)
                .FirstOrDefaultAsync(n => n.Id == nominationId);

            if (nomination == null)
                return false;

            var examDetail = new ExamDetail
            {
                NominationId = nominationId,
                InvoiceNumber = actionflowexamDetailDto.InvoiceNumber,
                InvoiceUrl = actionflowexamDetailDto.InvoiceUrl,
                CostInrWithoutTax = actionflowexamDetailDto.CostInrWithoutTax,
                CostInrWithTax = actionflowexamDetailDto.CostInrWithTax,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "system"
            };

            _dbcontext.ExamDetails.Add(examDetail);
            return await _dbcontext.SaveChangesAsync() > 0;
        }


        public async Task<MyCertification> GetByIdAsync(int id)
        {
            return await _dbcontext.MyCertifications.FindAsync(id);
        }
        public async Task DeleteAsync(int id)
        {
            var certification = await _dbcontext.MyCertifications.FindAsync(id);
            if (certification != null)
            {
                _dbcontext.MyCertifications.Remove(certification);
                await _dbcontext.SaveChangesAsync();
            }
        }

    }
}




    