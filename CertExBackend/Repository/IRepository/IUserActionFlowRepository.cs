using CertExBackend.DTOs;
using CertExBackend.Model;

namespace CertExBackend.Repository.IRepository
{
    public interface IUserActionFlowRepository
    {
        Task<Nomination> GetNominationByIdAsync(int nominationId);
        Task<CertificationExam> GetCertificationExamByIdAsync(int certificationId);
        Task<CertificationProvider> GetCertificationProviderByIdAsync(int providerId);
        Task UpdateNominationAsync(Nomination nomination);

        Task<bool> UploadCertificationAsync(ActionFlowMyCertificationDto certificationDto);
        Task<bool> PostInvoiceDetailsAsync(ActionFlowExamDetailDto actionflowexamDetailDto);

        Task<MyCertification> GetByIdAsync(int id);
        Task DeleteAsync(int id);

    }
}