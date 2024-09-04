using CertExBackend.DTOs;

namespace CertExBackend.Services.IServices
{
    public interface IUserActionFlowService 
    {
        Task<ActionFlowCertificationDto> GetCertificationDetailsAsync(int nominationId);
        Task<ActionFlowProviderDto> GetProviderDetailsAsync(int nominationId);
        Task<ActionFlowNominationDto> GetNominationDatesAsync(int nominationId);
        Task<bool> SetExamDateAsync(int nominationId, DateTime examDate);
        Task<bool> UpdateExamStatusAsync(int nominationId, string examStatus);

        Task<bool> UploadCertificationAsync(ActionFlowMyCertificationDto certificationDto);
        Task<bool> PostInvoiceDetailsAsync(ActionFlowExamDetailDto examDetailDto);

        Task DeleteCertificationAsync(int id);

    }
}

