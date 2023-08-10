using Microsoft.AspNetCore.Identity.UI.Services;

namespace livrariacandeias.Utility
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Add logic to send email
            return Task.CompletedTask;
        }
    }
}