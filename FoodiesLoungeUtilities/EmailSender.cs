
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace FoodiesLoungeUtilities
{
    public class EmailSender : IEmailSender
    {
        public class EmailSettings
        {
            public string EmailFrom { get; set; }
            public string SmtpHost { get; set; }
            public int SmtpPort { get; set; }
            public string SmtpUser { get; set; }
            public string SmtpPass { get; set; }
        }
        private readonly EmailSettings _emailSettings;
        private readonly ILogger<EmailSender> _logger;

        public EmailSender(IOptions<EmailSettings> appSettings, ILogger<EmailSender> logger)
        {
            _emailSettings = appSettings.Value;
            _logger = logger;
        }
        public Task SendEmailAsync(string emailto, string subject, string htmlMessage)
        {


            if (!string.IsNullOrEmpty(emailto))
            {
                try
                {
                    // create message
                    var email = new MimeMessage();

                    email.To.Add(MailboxAddress.Parse(emailto));
                    email.Subject = subject;
                    email.Body = new TextPart(TextFormat.Html) { Text = htmlMessage };

                    // send email
                    using var smtp = new SmtpClient();
                    smtp.Connect(_emailSettings.SmtpHost, _emailSettings.SmtpPort, SecureSocketOptions.StartTls);
                    smtp.Authenticate(_emailSettings.SmtpUser, _emailSettings.SmtpPass);
                    smtp.Send(email);
                    smtp.Disconnect(true);

                }
                catch (System.Exception x)
                {
                    _logger.LogError(x, "Email error");
                }
            }
            return Task.CompletedTask;
        }



    }
}
