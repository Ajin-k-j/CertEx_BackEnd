namespace CertExBackend.Services.IServices
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string body);
        Task SendEmailWithCcAsync(string to, string subject, string body, string cc);
    }
}
