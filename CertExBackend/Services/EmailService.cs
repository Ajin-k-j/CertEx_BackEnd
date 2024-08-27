﻿using CertExBackend.Services.IServices;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace CertExBackend.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Nomination System", _configuration["EmailSettings:From"]));
            message.To.Add(new MailboxAddress("", to));
            message.Subject = subject;

            message.Body = new TextPart("html") { Text = body };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_configuration["EmailSettings:Host"], int.Parse(_configuration["EmailSettings:Port"]), SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_configuration["EmailSettings:Username"], _configuration["EmailSettings:Password"]);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }

}
