namespace CertExBackend.DTOs
{
    public class UserActionFlowDto
    {
        // Properties from Nomination model
        public int NominationId { get; set; }
        public int CertificationId { get; set; }
        public int EmployeeId { get; set; }
        public string PlannedExamMonth { get; set; }
        public DateTime? ExamDate { get; set; }
        public bool IsDepartmentApproved { get; set; } = false;
        public bool IsLndApproved { get; set; } = false;
        public string ExamStatus { get; set; } = "Not Completed";
        public string NominationStatus { get; set; } = "Not Completed";

        // Properties from CertificationExam model
        public int CertificationExamId { get; set; }
        public int ProviderId { get; set; }
        public string CertificationName { get; set; }
        public string CertificationNominationStatus { get; set; } // Accepting, NotAccepting
        public string CertificationDescription { get; set; }
        public string CertificationOfficialLink { get; set; }
        public DateTime? NominationOpenDate { get; set; }
        public DateTime? NominationCloseDate { get; set; }

        // Properties from CertificationProvider model
        public int CertificationProviderId { get; set; }
        public string ProviderName { get; set; }

        // Properties from ExamDetail model
        public int ExamDetailId { get; set; }
        public int MyCertificationId { get; set; }
        public decimal CostInrWithoutTax { get; set; }
        public decimal CostInrWithTax { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceUrl { get; set; }
        public string UploadCertificateStatus { get; set; } // Uploaded, Not Uploaded
        public string SkillMatrixStatus { get; set; } // Updated, Not Updated
        public string ReimbursementStatus { get; set; } // Complete, Not Complete

        // Properties from MyCertification model
        public int MyCertificationRecordId { get; set; }
        public string Filename { get; set; }
        public string Url { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Credentials { get; set; }
    }
}

