using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using MimeKit;

namespace EmailService
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfig _emailConfig;

        public EmailSender(EmailConfig emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public void SendEmail(EmailModel email)
        {
            var emailMessage = CreateEmail(email);

            Send(emailMessage);
        }

        private void Send(MimeMessage emailMessage)
        {
            using var client = new SmtpClient();

            try
            {
                client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailConfig.Username, _emailConfig.Password);

                client.Send(emailMessage);
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }

        private MimeMessage CreateEmail(EmailModel mailModel)
        {
            IEnumerable<string> singleEmailRecipent = new List<string> {mailModel.To};
            var emailReceivers = new List<MailboxAddress>();
            emailReceivers.AddRange(singleEmailRecipent.Select(tempEmail => new MailboxAddress(tempEmail)));

            var email = new MimeMessage();
            email.From.Add(new MailboxAddress(_emailConfig.From));
            email.To.AddRange(emailReceivers);
            email.Subject = mailModel.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = mailModel.Body };

            return email;
        }
    }
}
