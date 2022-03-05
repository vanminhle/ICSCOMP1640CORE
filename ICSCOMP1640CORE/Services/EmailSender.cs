using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using System;
using System.Net;

namespace ICSCOMP1640CORE.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public AuthMessageSenderOptions Options { get; } //Set with Secret Manager.

        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute(Options.SendGridKey, subject, message, email);
        }

        public async Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("minhlbgcd191002@fpt.edu.vn", "ICSMailService"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress(email));

            msg.SetClickTracking(false, false);

            //var response = client.SendEmailAsync(msg);*/


            var response = await client.SendEmailAsync(msg);
            if (response.StatusCode != HttpStatusCode.OK
                && response.StatusCode != HttpStatusCode.Accepted)
            {
                var errorMessage = response.Body.ReadAsStringAsync().Result;
                throw new Exception($"Failed to send mail to, status code {response.StatusCode}, {errorMessage}");
            }
            //return client.SendEmailAsync(msg);
        }
    }

}
