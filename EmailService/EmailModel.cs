using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MimeKit;

namespace EmailService
{
    public class EmailModel
    {
        [Required]
        public List<MailboxAddress> To { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }

        public EmailModel(IEnumerable<string> to, string subject, string body)
        {
            To = new List<MailboxAddress>();

            To.AddRange(to.Select(x => new MailboxAddress(x)));
            Subject = subject;
            Body = body;
        }

        public EmailModel()
        { }
        
    }
}
