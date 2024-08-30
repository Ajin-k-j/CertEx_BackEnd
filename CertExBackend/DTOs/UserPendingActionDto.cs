namespace CertExBackend.DTOs
{
    public class UserPendingActionDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int CertificationId { get; set; }
        public string NominationStatusFromNomination { get; set; }
        public string NominationStatusFromCertificationExam { get; set; }
        public string CertificationName { get; set; }
    }
}
